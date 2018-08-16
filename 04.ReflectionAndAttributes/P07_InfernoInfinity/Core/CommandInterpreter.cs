using System;
using System.Linq;
using System.Reflection;

public class CommandInterpreter : ICommandInterpreter
{
    private IServiceProvider serviceProvider;

    public CommandInterpreter(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }

    public IExecutable InterpretCommand(string[] data, string commandName)
    {
        Assembly assembly = Assembly.GetCallingAssembly();
        Type typeCommand = assembly.GetTypes()
            .First(x => x.ToString() == commandName + "Command");

        FieldInfo[] fields = typeCommand.GetFields(BindingFlags.Public | BindingFlags.Instance)
            .Where(x => x.CustomAttributes.Any(y => y.AttributeType == typeof(InjectAttribute))).ToArray();

        object[] injectArgs = fields
                            .Select(f => this.serviceProvider.GetService(f.FieldType))
                            .ToArray();

        object[] args = new object[] { data }.Concat(injectArgs).ToArray();

        IExecutable instance = (IExecutable)Activator.CreateInstance(typeCommand, args);
        return instance;
    }
}

