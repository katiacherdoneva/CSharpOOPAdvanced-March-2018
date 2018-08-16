public abstract class Command : ICommand, IExecutable
{
    public Command(string[] data, IRespository respository)
    {
        this.Data = data;
        this.Respository = respository;
    }

    public string name => this.GetType().Name;

    public string[] Data { get; protected set; }

    [Inject]
    public IRespository Respository;

    public abstract void Execute();
}

