public interface IRespository
{
    void AddKey(Weapon weapon);

    void AddGem(string nameWeapon, Gem gem, int index);

    void RemoveGem(string nameWeaponRemove, int indexRemove);

    string PrintWeapon(string nameWeaponPrint);
}

