using Hkmp.Api.Client;
using Hkmp.Networking.Packet;

namespace {modName}.HKMP
{
    internal class {modName}ClientAddon : ClientAddon
    {
        protected override string Name
        { 
            get
            {
                return "{modName}";
            }
        }
        protected override string Version
        {
            get
            {
                return {modName}.Instance.GetVersion();
            }
        }

        public override bool NeedsNetwork
        {
            get
            {
                return true;
            }
        }

        public static {modName}ClientAddon Instance { get; private set; }

        public IClientApi {modName}ClientAddonApi { get; private set;}

        public override void Initialize(IClientApi clientApi)
        {
            Instance = this;

            {modName}ClientAddonApi = clientApi;

            var sender = clientApi.NetClient.GetNetworkSender<FromClientToServerPackets>(Instance);
            var receiver = clientApi.NetClient.GetNetworkReceiver<FromServerToClientPackets>(Instance, InstantiatePackets);

            receiver.RegisterPacketHandler<HelloClientFromServerToClientData>
            (
                FromServerToClientPackets.HelloClient,
                packetData =>
                {
                    {modName}.Instance.Log("Message from server: " + packetData.Message);
                }
            );

            clientApi.CommandManager.RegisterCommand(new {modName}Command());

            clientApi.ClientManager.ConnectEvent +=          OnConnect;
            clientApi.ClientManager.DisconnectEvent +=       OnDisconnect;
            clientApi.ClientManager.PlayerConnectEvent +=    OnPlayerConnect;
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
                case FromServerToClientPackets.HelloClient:
                    return new HelloServerFromClientToServerData();
                default:
                    return null;
            }
        }
    }
}