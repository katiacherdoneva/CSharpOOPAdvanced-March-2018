using System;

public class AddCommand : Command
{
    private GemFactory gemFactory;

    public AddCommand(string[] data, IRespository respository)
    : base(data, respository)
    {
        this.gemFactory = new GemFactory();
    }

    public override void Execute()
    {
        string nameWeapon = this.Data[0];
        int index = int.Parse(this.Data[1]);
        string[] clarityGem = this.Data[2]
            .Split(' ', StringSplitOptions.RemoveEmptyEntries);

        Gem gem = this.gemFactory.CreateGem(clarityGem);

        this.Respository.AddGem(nameWeapon, gem, index);
    }
}

