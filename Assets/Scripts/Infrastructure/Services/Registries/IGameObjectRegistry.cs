﻿using Assets.Scripts.ScriptableObjects;
using Assets.Scripts.SpaceShips;
using Assets.Scripts.Weapons;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.Registries
{
    public interface IGameObjectRegistry
    {
        void RegisterGameObject(IWeapon weapo, GameObject gameObject);
        void RegisterGameObject(ISpaceShip spaceShip, GameObject gameObject);
        void UnRegisterGameObject(GameObject gameObject);

        GameObject GetSpaceShipGameObject(ISpaceShip spaceShip);
        GameObject GetWeaponGameObject(IWeapon weapon);
    }
}
