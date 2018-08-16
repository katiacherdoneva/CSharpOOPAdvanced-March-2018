using _03BarracksFactory.Contracts;
using P03_BarraksWars.Core.Command;
using System;
using System.Linq;
using System.Reflection;

namespace P03_BarraksWars.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private IServiceProvider serviceProvider;

        public CommandInterpreter(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            string result = string.Empty;
            string command = data[0];

            Assembly assembly = Assembly.GetCallingAssembly();
            Type typeCommand = assembly.GetTypes()
             .FirstOrDefault(x => x.Name.ToLower() == command + "command");

            if (typeCommand == null)
            {
                throw new ArgumentException("Invalid command!");
            }

            if (!typeof(IExecutable).IsAssignableFrom(typeCommand))
            {
                throw new ArgumentException($"{typeCommand} is not valid a command.");
            }

            FieldInfo[] fields = typeCommand.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(x => x.CustomAttributes.Any(ca => ca.AttributeType == typeof(InjectAttribute))).ToArray();

            object[] injectArgs = fields
                             .Select(f => this.serviceProvider.GetService(f.FieldType))
                             .ToArray();

            object[] args = new object[] { data }.Concat(injectArgs).ToArray();

            IExecutable instance = (IExecutable)Activator.CreateInstance(typeCommand, args);
            return instance;
        }
    }
}
