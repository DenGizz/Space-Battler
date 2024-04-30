namespace Assets.Scripts.Entities.Weapons
{
    public interface IWeapon : IAttackable
    {
        float Damage { get; }
        float ColdDownTime { get; }

        bool CanShoot { get; }
    }
}