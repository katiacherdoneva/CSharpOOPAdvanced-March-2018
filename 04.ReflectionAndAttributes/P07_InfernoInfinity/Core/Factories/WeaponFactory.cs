using System;

public class WeaponFactory
{
    public Weapon CreateWeapon(string[] data)
    {
        string[] rarityAndWeaponType = data[0]
                                .Split(' ');

        Rarity rarityEnum = (Rarity)Enum.Parse(typeof(Rarity), rarityAndWeaponType[0]);

        Type type = Type.GetType(rarityAndWeaponType[1]);
        Weapon weapon = (Weapon)Activator.CreateInstance(type, new object[] { data[1] });
        weapon.Rarity = rarityEnum;

        return weapon;
    }
}

