using Hkmp.Api.Client;
using Hkmp.Networking.Packet;

namespace {addonName}.HKMP
{
    internal class {addonName}ClientAddon : ClientAddon
    {
        protected override string Name
        { 
            get
            {
                return "{addonName}";
            }
        }
        protected override string Version
        {
            get
            {
                return {addonName}.Instance.GetVersion();
            }
        }

        public override bool NeedsNetwork
        {
            get
            {
                return true;
            }
        }

        public static {addonName}ClientAddon Instance { get; private set; }

        public IClientApi {addonName}ClientAddonApi { get; private set;}

        public override void Initialize(IClientApi clientApi)
        {
            Instance = this;

            {addonName}ClientAddonApi = clientApi;

            var sender = clientApi.NetClient.GetNetworkSender<FromClientToServerPackets>(Instance);
            var receiver = clientApi.NetClient.GetNetworkReceiver<FromServerToClientPackets>(Instance, InstantiatePackets);

            receiver.RegisterPacketHandler<MessageFromServerToClientData>
            (
                FromServerToClientPackets.Message,
                packetData =>
                {
                    {addonName}.Instance.Log("Message from server: " + packetData.Message);
                }
            );

            clientApi.CommandManager.RegisterCommand(new {addonName}Command());

            clientApi.ClientManager.ConnectEvent          += OnConnect;
            clientApi.ClientManager.DisconnectEvent       += OnDisconnect;
            clientApi.ClientManager.PlayerConnectEvent    += OnPlayerConnect;
            clientApi.ClientManager.PlayerDisconnectEvent += OnPlayerDisconnect;
            clientApi.ClientManager.PlayerEnterSceneEvent += OnPlayerEnterScene;
            clientApi.ClientManager.PlayerLeaveSceneEvent += OnPlayerLeaveScene;
        }

        private void OnConnect()
        {

        }

        private void OnDisconnect()
        {

        }

        private void OnPlayerConnect(IClientPlayer player)
        {

        }

        private void OnPlayerDisconnect(IClientPlayer player)
        {

        }

        private void OnPlayerEnterScene(IClientPlayer player)
        {

        }

        private void OnPlayerLeaveScene(IClientPlayer player)
        {

        }

        private static IPacketData InstantiatePackets(FromServerToClientPackets clientPacket)
        {
            switch (clientPacket)
            {
                case FromServerToClientPackets.Message:
                    return new MessageFromClientToServerData();
                default:
                    return null;
            }
        }
    }
}