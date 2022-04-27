using Hkmp.Api.Command.Client;

namespace {addonName}.HKMP
{
    internal class {addonName}Command : IClientCommand
    {
        public string Trigger { get; } = "{addonName}";

        public string[] Aliases { get; } = new[]
        {
            "HelloWorld",   "/HelloWorld",  @"\HelloWorld",
            "HELLOWORLD",   "/HELLOWORLD",  @"\HELLOWORLD",
            "helloworld",   "/helloworld",  @"\helloworld",
            "hello",        "/hello",       @"\hello",
            "HELLO",        "/HELLO",       @"\HELLO",
        };

        public void Execute(string[] arguments)
        {
            var {addonName}Instance = {addonName}ClientAddon.Instance;
            var sender = {addonName}Instance.{addonName}ClientAddonApi.NetClient.GetNetworkSender<FromClientToServerPackets>({addonName}Instance);

            string message = "Hello, Server!";
            if (arguments.Length > 1)
            {
                message = arguments[1];
            }

            sender.SendSingleData(FromClientToServerPackets.Message, new MessageFromClientToServerData
            {
                Message = message,
            });
        }
    }
}