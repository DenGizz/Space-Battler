using Assets.Scripts.Units;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.Factories
{
    public interface IUnitRegistry
    {
        public ICombatUnit PlayerCombatUnit { get; set; }
        public ICombatUnit EnemyCombatUnit { get; set; }
    }
}