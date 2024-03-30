using Assets.Scripts.Units;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.Factories
{
    public interface IUnitRegistry
    {
        public IEnumerable<ICombatUnit> CombatUnits { get; }

        public void RegisterCombatUnit(ICombatUnit unit);
        public void UnregisterCombatUnit(ICombatUnit unit);
    }
}