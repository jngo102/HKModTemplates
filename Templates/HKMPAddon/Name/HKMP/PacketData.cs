using Hkmp.Networking.Packet;

namespace {name}.HKMP
{
#region Server to Client
    /// <summary>
    /// Packet to send a message from the server to a client.
    /// </summary>
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

        /// <summary>
        /// The ID of the player to send the server's message to.
        /// </summary>
        public ushort PlayerId { get; set; }

        /// <summary>
        /// The message that the server will send to the client.
        /// </summary>
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

    /// <summary>
    /// Determines the type of packet that is sent from the server to a client.
    /// </summary>
    public enum FromServerToClientPackets
    {
        SendMessage,
    }
#endregion

#region Client to Server
    /// <summary>
    /// Packet to send a message from a client to the server.
    /// </summary>
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

        /// <summary>
        /// The message that a client will send to the server.
        /// </summary>
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

    /// <summary>
    /// Determines the type of packet that is sent from a client to the server.
    /// </summary>
    public enum FromClientToServerPackets
    {
        SendMessage,
    }
#endregion
}