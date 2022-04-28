using Hkmp.Api.Client;
using Hkmp.Networking.Packet;
using System.Reflection;

namespace {name}.HKMP
{
    /// <summary>
    /// The client add-on class.
    /// </summary>
    internal class {name}ClientAddon : ClientAddon
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
                return {name}.Instance.GetVersion();
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
        /// The global instance of the client add-on.
        /// </summary>
        public static {name}ClientAddon Instance { get; private set; }

        /// <summary>
        /// A public client API object that is accessible from other classes.
        /// </summary>
        public static IClientApi ClientApi { get; private set;}

        public override void Initialize(IClientApi clientApi)
        {
            Instance = this;

            ClientApi = clientApi;

            // Sends packets from this client to the server.
            var sender = clientApi.NetClient.GetNetworkSender<FromClientToServerPackets>(this);

            // Receives and handles packets from the server to this client.
            var receiver = clientApi.NetClient.GetNetworkReceiver<FromServerToClientPackets>(this, InstantiatePackets);

            receiver.RegisterPacketHandler<MessageFromServerToClientData>
            (
                FromServerToClientPackets.SendMessage,
                packetData =>
                {
                    {name}.Instance.Log("[Client] Message from server: " + packetData.Message);
                }
            );

            // Register an instance of the client command class.
            clientApi.CommandManager.RegisterCommand(new {name}Command());

            clientApi.ClientManager.ConnectEvent += () => 
            {
                {name}.Instance.Log("[Client] You have connected to the server.");
            };

            clientApi.ClientManager.DisconnectEvent += () =>
            {
                {name}.Instance.Log("[Client] You have disconnected from the server.");
            };

            clientApi.ClientManager.PlayerConnectEvent += (player) =>
            {
                {name}.Instance.Log($"[Client] Player {player.Username} has connected to the server.");
            };

            clientApi.ClientManager.PlayerDisconnectEvent += (player) =>
            {
                {name}.Instance.Log($"[Client] Player {player.Username} has disconnected from the server.");
            };

            clientApi.ClientManager.PlayerEnterSceneEvent += (player) =>
            {
                {name}.Instance.Log($"[Client] Player {player.Username} has entered a scene.");
            };

            clientApi.ClientManager.PlayerLeaveSceneEvent += (player) =>
            {
                {name}.Instance.Log($"[Client] Player {player.Username} has left a scene.");
            };
        }

        /// <summary>
        /// Handle server packets according to their type.
        /// </summary>
        private static IPacketData InstantiatePackets(FromServerToClientPackets clientPacket)
        {
            switch (clientPacket)
            {
                case FromServerToClientPackets.SendMessage:
                    return new MessageFromClientToServerData();
                default:
                    return null;
            }
        }
    }
}