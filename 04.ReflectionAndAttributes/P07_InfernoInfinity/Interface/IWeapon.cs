public interface IWeapon
{
    string Name { get; }

    int DamageMin { get; }

    int DamageMax { get; }

    int NOfSockets { get; }

    int Strength { get; }

    int Agility { get; }

    int Vitality { get; }

    void IncreaseWithRarity();

    void BonusGem(Gem gem);
}

