using Hkmp.Api.Command.Client;

namespace {name}.HKMP
{
    /// <summary>
    /// A client command to send a message to the server, which responds back.
    /// </summary>
    internal class {name}Command : IClientCommand
    {
        public string Trigger { get; } = "message";

        public string[] Aliases { get; } = new[]
        {
            "/message", @"\message",
            "Message", "/Message", @"\Message",
            "MESSAGE", "/MESSAGE", @"\MESSAGE",
            "msg", "/msg", @"\msg", 
            "MSG", "/MSG", @"\MSG",
        };

        public void Execute(string[] arguments)
        {
            // Fetch the client API instance from the client API class.
            var sender = {name}ClientAddon.ClientApi.NetClient.GetNetworkSender<FromClientToServerPackets>({name}ClientAddon.Instance);

            string message = "Hello, Server!";
            
            // If an argument has been passed into the command line, read it into the message string.
            if (arguments.Length > 1)
            {
                message = arguments[1];
            }

            // Send the message to the server.
            sender.SendSingleData(FromClientToServerPackets.SendMessage, new MessageFromClientToServerData
            {
                Message = message,
            });
        }
    }
}