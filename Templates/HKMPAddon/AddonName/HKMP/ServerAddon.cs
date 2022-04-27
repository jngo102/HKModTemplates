using Hkmp.Api.Server;
using Hkmp.Networking.Packet;

namespace {addonName}.HKMP
{
    internal class {addonName}ServerAddon : ServerAddon
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

        public static {addonName}ServerAddon Instance { get; private set; }

        public override void Initialize(IServerApi serverApi)
        {
            Instance = this;

            var sender = serverApi.NetServer.GetNetworkSender<FromServerToClientPackets>(Instance);
            var receiver = serverApi.NetServer.GetNetworkReceiver<FromClientToServerPackets>(Instance, InstantiatePackets);

            receiver.RegisterPacketHandler<MessageFromClientToServerData>
            (
                FromClientToServerPackets.Message,
                (id, packetData) =>
                {
                    {addonName}.Instance.Log($"Message from client {id}: {packetData.Message}");

                    sender.SendSingleData(FromServerToClientPackets.Message, new MessageFromServerToClientData
                    {
                        Message = "Hello, Client!",
                    }, id);
                }
            );

            serverApi.ServerManager.PlayerConnectEvent    += OnPlayerConnect;
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
                case FromClientToServerPackets.Message:
                    return new MessageFromServerToClientData();
                default:
                    return null;
            }
        }
    }
}