using Hkmp.Api.Server;
using Hkmp.Networking.Packet;
using System.Reflection;

namespace {name}.HKMP
{
    /// <summary>
    /// The server add-on class.
    /// </summary>
    internal class {name}ServerAddon : ServerAddon
    {
        protected override string Name
        { 
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Name;
            }
        }

        protected override string Version
        {
            get
            {
                // We cannot get the mod's version or the add-on will not run on a standalone server.
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public override bool NeedsNetwork
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// The global instance of the server add-on.
        /// </summary>
        public static {name}ServerAddon Instance { get; private set; }

        public override void Initialize(IServerApi serverApi)
        {
            Instance = this;

            // Sends packets from the server to a client.
            var sender = serverApi.NetServer.GetNetworkSender<FromServerToClientPackets>(Instance);
            
            // Receives and handles packets from a client to the server.
            var receiver = serverApi.NetServer.GetNetworkReceiver<FromClientToServerPackets>(Instance, InstantiatePackets);

            receiver.RegisterPacketHandler<MessageFromClientToServerData>
            (
                FromClientToServerPackets.SendMessage,
                (id, packetData) =>
                {
                    {name}.Instance.Log($"[Server] Message from client {id}: {packetData.Message}");

                    sender.SendSingleData(FromServerToClientPackets.SendMessage, new MessageFromServerToClientData
                    {
                        Message = "Hello, Client!",
                    }, id);
                }
            );

            serverApi.ServerManager.PlayerConnectEvent += (player) =>
            {
                {name}.Instance.Log($"[Server] Player of ID {player.Id} has connected to the server.");
            };

            serverApi.ServerManager.PlayerDisconnectEvent += (player) =>
            {
                {name}.Instance.Log($"[Server] Player of ID {player.Id} has disconnected to the server.");
            };

            serverApi.ServerManager.PlayerEnterSceneEvent += (player) =>
            {
                {name}.Instance.Log($"[Server] Player of ID {player.Id} has entered a scene.");
            };

            serverApi.ServerManager.PlayerLeaveSceneEvent += (player) =>
            {
                {name}.Instance.Log($"[Server] Player of ID {player.Id} has left a scene.");
            };
        }

        /// <summary>
        /// Handle client packets according to their type.
        /// </summary>
        private static IPacketData InstantiatePackets(FromClientToServerPackets serverPacket)
        {
            switch (serverPacket)
            {
                case FromClientToServerPackets.SendMessage:
                    return new MessageFromServerToClientData();
                default:
                    return null;
            }
        }
    }
}