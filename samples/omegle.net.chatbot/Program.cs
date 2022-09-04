using omegle.net.chatbot;

/*IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
    })
    .Build();*/

    var client = new omegle.net.Client(new System.Net.Http.HttpClient());
    await client.ConnectAsync(System.Threading.CancellationToken.None);

//await host.RunAsync();
