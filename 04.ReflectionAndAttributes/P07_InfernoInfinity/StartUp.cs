using System;
using Microsoft.Extensions.DependencyInjection;
public class StartUp
{
    static void Main()
    {
        IServiceProvider serviceProvider = ConfigureServices();
        ICommandInterpreter commandInterpreter = new CommandInterpreter(serviceProvider);
        IRunnable engine = new Engine(commandInterpreter);
        engine.Run();
    }

    private static IServiceProvider ConfigureServices()
    {
        IServiceCollection serviceCollection = new ServiceCollection();
        serviceCollection.AddSingleton<IRespository, Respository>();

        IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
        return serviceProvider;
    }
}

