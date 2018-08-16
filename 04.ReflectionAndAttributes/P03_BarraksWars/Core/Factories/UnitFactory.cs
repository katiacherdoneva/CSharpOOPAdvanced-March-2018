namespace _03BarracksFactory.Core.Factories
{
    using System;
    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        private const string unitNamespace = "_03BarracksFactory.Models.Units.";

        public IUnit CreateUnit(string unitType)
        {
            var typeOfUnit = Type.GetType($"{unitNamespace}{unitType}", true);

            return (IUnit)Activator.CreateInstance(typeOfUnit);
        }
    }
}
