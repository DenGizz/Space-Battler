namespace Assets.Scripts.SpaceShips.SpaceShipAttributes
{
    public class HealthAttribute : IHealthAttribute
    {
        public float BaseHP { get; }

        public float HP { get; private set; }

        public HealthAttribute(float currentHP, float baseHP)
        {
            HP = currentHP;
            BaseHP = baseHP;
        }

        public void TakeDamage(float damageAmount)
        {
            HP -= damageAmount;
        }

        public void RestoreHP(float restoreAmount)
        {
            HP += restoreAmount;
        }
    }
}