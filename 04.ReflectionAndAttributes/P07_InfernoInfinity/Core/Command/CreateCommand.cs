using System;

public class CreateCommand : Command
{
    private WeaponFactory weaponFactory;

    public CreateCommand(string[] data, IRespository respository)
        : base(data, respository)
    {
        this.weaponFactory = new WeaponFactory();
    }

    public override void Execute()
    {
        Weapon weapon = this.weaponFactory.CreateWeapon(this.Data);

        this.Respository.AddKey(weapon);
    }
}

