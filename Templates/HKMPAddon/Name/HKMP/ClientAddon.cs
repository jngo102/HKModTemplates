using Hkmp.Api.Client;
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
        /// Holds a reference to the client API passed into Initialize.
        /// </summary>
        private IClientApi _clientApi;

        public override void Initialize(IClientApi clientApi)
        {
            Instance = this;
            _clientApi = clientApi;

            // Sends packets from this client to the server.
            var sender = clientApi.NetClient.GetNetworkSender<FromClientToServerPackets>(Instance);

            // Receives and handles packets from the server to this client.
            var receiver = clientApi.NetClient.GetNetworkReceiver<FromServerToClientPackets>(Instance, clientPacket =>
            {
                return clientPacket switch
                {
                    FromServerToClientPackets.SendMessage => new MessageFromServerToClientData(),
                    _ => null
                };
            });

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
        /// Sends a message from the client to the server.
        /// </summary>
        public void SendMessage(string message)
        {
            var sender = _clientApi.NetClient.GetNetworkSender<FromClientToServerPackets>(Instance);
            sender.SendSingleData(FromClientToServerPackets.SendMessage, new MessageFromClientToServerData
            {
                Message = message,
            });
        }
    }
}