public class Sword : Weapon
{
    public Sword(string name)
        : base(name)
    {
        this.DamageMin = 4;
        this.DamageMax = 6;
        this.NOfSockets = 3;
    }
}

