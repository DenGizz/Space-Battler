﻿using Assets.Scripts.Units;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.Factories
{
    public interface IUnitRegistry
    {
        public ISpaceShip PlayerSpaceShip { get; set; }
        public ISpaceShip EnemySpaceShip { get; set; }
    }
}