using _03BarracksFactory.Contracts;
using _03BarracksFactory.Core.Factories;

namespace P03_BarraksWars.Core.Command
{
    public class AddCommand : Command
    {
        [Inject]
        private IRepository repository;
        [Inject]
        private IUnitFactory unitFactory;

        public AddCommand(string[] data, IRepository repository, IUnitFactory unitFactory) 
            : base(data)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }

        public override string Execute()
        {
            string unitType = Data[1];
            IUnit unitToAdd = unitFactory.CreateUnit(unitType);
            this.repository.AddUnit(unitToAdd);
            string output = unitType + " added!";
            return output;
        }
    }
}
