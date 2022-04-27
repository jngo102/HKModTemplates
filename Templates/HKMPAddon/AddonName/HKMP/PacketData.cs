using Hkmp.Networking.Packet;

namespace {addonName}.HKMP
{
#region Server to Client
    internal class MessageFromServerToClientData : IPacketData
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
        Message,
    }
#endregion

#region Client to Server
    internal class MessageFromClientToServerData : IPacketData
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
        Message,
    }
#endregion
}