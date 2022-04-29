using Hkmp.Api.Server;
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

        public override void Initialize(IServerApi serverApi)
        {
            // Sends packets from the server to a client.
            var sender = serverApi.NetServer.GetNetworkSender<FromServerToClientPackets>(this);
            
            // Receives and handles packets from a client to the server.
            var receiver = serverApi.NetServer.GetNetworkReceiver<FromClientToServerPackets>(this, serverPacket =>
            {
                return serverPacket switch
                {
                    FromClientToServerPackets.SendMessage => new MessageFromClientToServerData(),
                    _ => null
                };
            });

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
    }
}