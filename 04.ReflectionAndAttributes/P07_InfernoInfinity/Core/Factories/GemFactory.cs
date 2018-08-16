using System;

public class GemFactory
{
    public Gem CreateGem(string[] clarityGem)
    {
        Clarity clarity = (Clarity)Enum.Parse(typeof(Clarity), clarityGem[0]);
        Type typeGem = Type.GetType(clarityGem[1]);
        Gem gem = (Gem)Activator.CreateInstance(typeGem, false);
        gem.Clarity = clarity;

        return gem;
    }
}

