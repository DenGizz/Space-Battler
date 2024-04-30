using System.Collections;
using Assets.Scripts.Entities.SpaceShips;
using Assets.Scripts.Entities.Weapons;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services
{
    public interface IWeaponAttachService
    {
        void AttachWeaponToSpaceShip(ISpaceShip spaceShip, IWeapon weapon);
        bool CanAttachWeaponToSpaceShip(ISpaceShip spaceShip, IWeapon weapon);
    }
}