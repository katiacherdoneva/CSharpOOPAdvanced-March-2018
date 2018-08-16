public class RemoveCommand : Command
{
    public RemoveCommand(string[] data, IRespository respository)
    : base(data, respository)
    {
    }

    public override void Execute()
    {
        int indexRemove = int.Parse(this.Data[1]);
        string nameWeaponRemove = this.Data[0];

        this.Respository.RemoveGem(nameWeaponRemove, indexRemove);
    }
}

