using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class Engine : IRunnable
{
    private ICommandInterpreter commandInterpreter;

    public Engine(ICommandInterpreter commandInterpreter)
    {
        this.commandInterpreter = commandInterpreter;
    }

    public void Run() 
    {
        string input = string.Empty;
        while ((input = Console.ReadLine()) != "END")
        {
            string[] commandOfArgs = input
                .Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            string command = commandOfArgs[0];
            string[] data = commandOfArgs.Skip(1).ToArray();

            var instance = this.commandInterpreter.InterpretCommand(data, command);

            MethodInfo method = typeof(IExecutable).GetMethods().First();

            method.Invoke(instance, null);
        }
    }
}

