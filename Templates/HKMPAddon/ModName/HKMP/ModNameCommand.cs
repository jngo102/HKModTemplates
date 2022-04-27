using Hkmp.Api.Command.Client;

namespace {modName}.HKMP
{
    internal class {modName}Command : IClientCommand
    {
        public string Trigger { get; } = "{modName}";

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
            var {modName}Instance = {modName}ClientAddon.Instance;
            var sender = {modName}Instance.{modName}ClientAddonApi.NetClient.GetNetworkSender<FromClientToServerPackets>({modName}Instance);

            string message = "Hello, Server!";
            if (arguments.Length > 1)
            {
                message = arguments[1];
            }

            sender.SendSingleData(FromClientToServerPackets.HelloServer, new HelloServerFromClientToServerData
            {
                Message = message,
            });
        }
    }
}