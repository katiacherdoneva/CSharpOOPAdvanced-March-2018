
using _03BarracksFactory.Contracts;

namespace P03_BarraksWars.Core.Command
{
    public abstract class Command : IExecutable
    {
        protected Command(string[] data)
        {
            this.Data = data;
        }

        protected string[] Data
        {
            get;
            private set;
        }

        public abstract string Execute();
    }
}