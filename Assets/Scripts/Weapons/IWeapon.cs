using Assets.Scripts.SpaceShips;

namespace Assets.Scripts.Weapons
{
    public interface IWeapon : IAttackable
    {
        float Damage { get; }
        float ColdDownTime { get; }

        bool CanShoot { get; }
    }
}