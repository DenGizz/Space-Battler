using Assets.Scripts.Entities.Weapons;

namespace Assets.Scripts.Infrastructure.Gameplay.GameObjectDestroyers
{
    public interface IWeaponDestroyer
    {
        void Destroy(IWeapon weapon);
    }
}
