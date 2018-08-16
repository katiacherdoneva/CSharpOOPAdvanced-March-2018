using System;
using System.Collections.Generic;
using System.Linq;

public abstract class Weapon : IWeapon
{
    private Rarity rarity;

    protected Weapon(string name)
    {
        this.Name = name;
        this.Strength = 0;
        this.Agility = 0;
        this.Vitality = 0;
    }

    public string Name { get; protected set; }

    public int DamageMin { get; protected set; }

    public int DamageMax { get; protected set; }

    public int NOfSockets { get; protected set; }

    public Rarity Rarity
    {
        get { return rarity; }
        set
        {            
            rarity = value;
            IncreaseWithRarity();
        }
    }

    public int Strength { get; protected set; }

    public int Agility { get; protected set; }

    public int Vitality { get; protected set; }

    public virtual void IncreaseWithRarity()
    {
        int n = (int)this.Rarity;

        this.DamageMin *= n;
        this.DamageMax *= n;
    }

    public virtual void BonusGem(Gem gem)
    {
        this.Strength += gem.StrengthBonus;
        this.Agility += gem.AgilityBonus;
        this.Vitality += gem.VitalityBonus;       
    }

    public virtual void SumDamage()
    {
        this.DamageMin += (this.Strength * 2);
        this.DamageMax += (this.Strength * 3);

        this.DamageMin += (this.Agility * 1);
        this.DamageMax += (this.Agility * 4);
    }
}

