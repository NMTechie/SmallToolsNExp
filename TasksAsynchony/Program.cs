// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TasksAsynchony;

Console.WriteLine("Hello, World!");
IHost host = Host.CreateDefaultBuilder(args)
        .ConfigureAppConfiguration((configBuilder) =>
        {
            configBuilder.AddJsonFile("appsettings.json")
            .AddEnvironmentVariables()
            .Build();
        })
        .ConfigureServices((hostContext, services) =>
        {
            IConfiguration configuration = hostContext.Configuration;
            #region Dependency Injection for Application (Need to Refactor)
            services.AddTransient(typeof(ASyncClass1));
            services.AddTransient(typeof(ASyncClass2));
            services.AddTransient(typeof(SyncClass1));
            services.AddTransient(typeof(ASyncClass3));
            #endregion
        })
        .Build();
await host.Services.GetService<ASyncClass1>().DoWorkAsyncClass1();
