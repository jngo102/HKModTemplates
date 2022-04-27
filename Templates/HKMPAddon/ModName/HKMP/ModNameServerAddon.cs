using Hkmp.Api.Server;
using Hkmp.Networking.Packet;

namespace {modName}.HKMP
{
    internal class {modName}ServerAddon : ServerAddon
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

        public static {modName}ServerAddon Instance { get; private set; }

        public override void Initialize(IServerApi serverApi)
        {
            Instance = this;

            var sender = serverApi.NetServer.GetNetworkSender<FromServerToClientPackets>(Instance);
            var receiver = serverApi.NetServer.GetNetworkReceiver<FromClientToServerPackets>(Instance, InstantiatePackets);

            receiver.RegisterPacketHandler<HelloServerFromClientToServerData>
            (
                FromClientToServerPackets.HelloServer,
                (id, packetData) =>
                {
                    {modName}.Instance.Log($"Message from client {id}: {packetData.Message}");

                    sender.SendSingleData(FromServerToClientPackets.HelloClient, new HelloClientFromServerToClientData
                    {
                        Message = "Hello, Client!",
                    }, id);
                }
            );

            serverApi.ServerManager.PlayerConnectEvent +=    OnPlayerConnect;
            serverApi.ServerManager.PlayerDisconnectEvent += OnPlayerDisconnect;
            serverApi.ServerManager.PlayerEnterSceneEvent += OnPlayerEnterScene;
            serverApi.ServerManager.PlayerLeaveSceneEvent += OnPlayerLeaveScene;
        }

        private void OnPlayerConnect(IServerPlayer player)
        {

        }

        private void OnPlayerDisconnect(IServerPlayer player)
        {

        }

        private void OnPlayerEnterScene(IServerPlayer player)
        {

        }

        private void OnPlayerLeaveScene(IServerPlayer player)
        {

        }

        private static IPacketData InstantiatePackets(FromClientToServerPackets serverPacket)
        {
            switch (serverPacket)
            {
                case FromClientToServerPackets.HelloServer:
                    return new HelloClientFromServerToClientData();
                default:
                    return null;
            }
        }
    }
}