using System.Collections.Generic;
using System.Linq;

public class Respository : IRespository
{
    private Dictionary<Weapon, Gem[]> weapons = new Dictionary<Weapon, Gem[]>();

    public Respository()
    {
        this.weapons = new Dictionary<Weapon, Gem[]>();
    }

    public void AddKey(Weapon weapon)
    {
        weapons.Add(weapon, new Gem[weapon.NOfSockets]);
    }

    public void AddGem(string nameWeapon, Gem gem, int index)
    {
        Weapon weapon = this.weapons
            .FirstOrDefault(x => x.Key.Name == nameWeapon).Key;

        if (weapon != null && index >= 0 && index < weapons[weapon].Length)
        {
            this.weapons[weapon][index] = gem;
        }
    }

    public string PrintWeapon(string nameWeaponPrint)
    {
        Weapon weaponPrint = weapons.FirstOrDefault(x => x.Key.Name == nameWeaponPrint).Key;

        foreach (var g in weapons[weaponPrint])
        {
            if (g != null)
            {
                weapons.FirstOrDefault(x => x.Key.Name == nameWeaponPrint).Key.BonusGem(g);
            }
        }

        weapons.FirstOrDefault(x => x.Key.Name == nameWeaponPrint).Key.SumDamage();

        Weapon result = weapons.FirstOrDefault(x => x.Key.Name == nameWeaponPrint).Key;
        string output = $"{result.Name}: {result.DamageMin}-{result.DamageMax} Damage," +
             $" +{result.Strength} Strength, +{result.Agility} Agility, +{result.Vitality} Vitality";

        return output;
    }

    public void RemoveGem(string nameWeaponRemove, int indexRemove)
    {
        Weapon weaponRemove = weapons.FirstOrDefault(x => x.Key.Name == nameWeaponRemove).Key;
        if (weaponRemove != null && indexRemove >= 0 && indexRemove < weapons[weaponRemove].Length)
        {
            weapons[weaponRemove][indexRemove] = null;
        }
    }
}

