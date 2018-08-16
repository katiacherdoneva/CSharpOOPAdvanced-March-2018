public class Axe : Weapon
{
    public Axe(string name)
        : base(name)
    {
        this.DamageMin = 5;
        this.DamageMax = 10;
        this.NOfSockets = 4;
    }
}

