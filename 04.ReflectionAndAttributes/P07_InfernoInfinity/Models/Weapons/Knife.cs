public class Knife : Weapon
{
    public Knife(string name)
        : base(name)
    {
        this.DamageMin = 3;
        this.DamageMax = 4;
        this.NOfSockets = 2;
    }
}

