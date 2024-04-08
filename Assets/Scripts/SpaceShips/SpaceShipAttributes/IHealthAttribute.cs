namespace Assets.Scripts.SpaceShips.SpaceShipAttributes
{
    public interface IHealthAttribute
    {
        float BaseHP { get; }
        float HP { get; }

        void TakeDamage(float damageAmount);
        void RestoreHP(float restoreAmount);
    }
}
