using Hkmp.Networking.Packet;

namespace {modName}.HKMP
{
#region Server to Client
    internal class HelloClientFromServerToClientData : IPacketData
    {
        public bool IsReliable
        {
            get
            {
                return true;
            }
        }

        public bool DropReliableDataIfNewerExists
        {
            get
            {
                return true;
            }
        }

        public ushort PlayerId { get; set; }
        public string Message { get; set; }

        public void ReadData(IPacket packet)
        {
            PlayerId = packet.ReadUShort();
            Message = packet.ReadString();
        }

        public void WriteData(IPacket packet)
        {
            packet.Write(PlayerId);
            packet.Write(Message);
        }
    }

    public enum FromServerToClientPackets
    {
        HelloClient,
    }
#endregion

#region Client to Server
    internal class HelloServerFromClientToServerData : IPacketData
    {
        public bool IsReliable
        {
            get
            {
                return true;
            }
        }

        public bool DropReliableDataIfNewerExists
        {
            get
            {
                return true;
            }
        }

        public string Message { get; set; }

        public void ReadData(IPacket packet)
        {
            Message = packet.ReadString();
        }

        public void WriteData(IPacket packet)
        {
            packet.Write(Message);
        }
    }

    public enum FromClientToServerPackets
    {
        HelloServer,
    }
#endregion
}