using Assets.Scripts.Entities.SpaceShips;
using UnityEngine;

namespace Assets.Scripts.UI.BattleUI
{
    [AddComponentMenu("UI/HealthView")]
    public class HealthView : MonoBehaviour
    {
        private ISpaceShip _spaceShip;
        [SerializeField] private GameObject _healthGreenRow;


        public void SetSpaceShip(ISpaceShip spaceShip)
        {
            _spaceShip = spaceShip;
        }

        private void LateUpdate()
        {
            if (_spaceShip == null)
                return;

            _healthGreenRow.transform.localScale = new Vector3(_spaceShip.Data.HealthPoints/ _spaceShip.Config.MaxHP, 1, 1);
        }
    }
}
