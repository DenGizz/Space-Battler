using Assets.Scripts.Entities.Weapons;

namespace Assets.Scripts.Infrastructure.Destroyers
{
    public interface IWeaponDestroyer
    {
        void Destroy(IWeapon weapon);
    }
}
