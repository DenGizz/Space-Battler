namespace Assets.Scripts.Units
{
    public interface IWeapon
    {
        float Damage { get; }
        float ColdDownTime { get; }

        bool CanShoot { get; }
        void Shoot(IDamagable target);
    }
}