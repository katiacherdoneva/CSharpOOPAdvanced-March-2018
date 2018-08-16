using _03BarracksFactory.Contracts;

namespace P03_BarraksWars.Core.Command
{
    public class RetireCommand : Command
    {
        [Inject]
        private IRepository repository;

        public RetireCommand(string[] data, IRepository repository) 
            : base(data)
        {
            this.repository = repository;
        }

        public override string Execute()
        {
            var unitToRemove = this.Data[1];
            this.repository.RemoveUnit(unitToRemove);
            return $"{unitToRemove} retired!";
        }
    }
}
