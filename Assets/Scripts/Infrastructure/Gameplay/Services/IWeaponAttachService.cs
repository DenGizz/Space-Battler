using Assets.Scripts.Entities.SpaceShips;
using Assets.Scripts.Entities.Weapons;

namespace Assets.Scripts.Infrastructure.Gameplay.Services
{
    public interface IWeaponAttachService
    {
        void AttachWeaponToSpaceShip(ISpaceShip spaceShip, IWeapon weapon);
        bool CanAttachWeaponToSpaceShip(ISpaceShip spaceShip, IWeapon weapon);
    }
}