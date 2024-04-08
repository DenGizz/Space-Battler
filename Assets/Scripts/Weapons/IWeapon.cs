using Assets.Scripts.SpaceShips;

namespace Assets.Scripts.Weapons
{
    public interface IWeapon
    {
        float Damage { get; }
        float ColdDownTime { get; }

        bool CanShoot { get; }
        void Shoot(IDamagable target);
    }
}