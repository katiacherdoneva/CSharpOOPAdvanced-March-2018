using System;

public class PrintCommand : Command
{
    public PrintCommand(string[] data, IRespository respository) 
        : base(data, respository)
    {
    }

    public override void Execute()
    {
        string nameWeaponPrint = this.Data[0];

        string result = this.Respository.PrintWeapon(nameWeaponPrint);

        Console.WriteLine(result);
    }
}

