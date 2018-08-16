public interface ICommand : IExecutable
{
    string name { get; }

    string[] Data { get; }
}

