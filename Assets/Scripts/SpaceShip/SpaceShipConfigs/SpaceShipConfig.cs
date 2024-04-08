namespace Assets.Scripts.SpaceShip.SpaceShipConfigs
{
    public class SpaceShipConfig
    {
        public float MaxHP { get; }
        public int WeaponSlots { get; }

        public SpaceShipConfig(float maxHP, int weaponSlots)
        {
            MaxHP = maxHP;
            WeaponSlots = weaponSlots;
        }
    }
}
