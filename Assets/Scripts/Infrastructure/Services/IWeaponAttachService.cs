using System.Collections;
using Assets.Scripts.SpaceShips;
using Assets.Scripts.Weapons;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services
{
    public interface IWeaponAttachService
    {
        void AttachWeaponToSpaceShip(ISpaceShip spaceShip, IWeapon weapon);
        bool CanAttachWeaponToSpaceShip(ISpaceShip spaceShip, IWeapon weapon);
    }
}