using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Battles;
using Assets.Scripts.Entities.SpaceShips;
using Assets.Scripts.Infrastructure.Ui.Factories;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.UI.ViewModels
{
    public class BattleView : MonoBehaviour
    {
        private BattleData _battleData;
        [SerializeField] private Vector2 _viewSpawnOffset;

        private Dictionary<ISpaceShip, HealthView> _spaceShipToHealthViewMap = new Dictionary<ISpaceShip, HealthView>();

        private IUiElementsFactory _uiFactory;

        [Inject]
        public void Construct(IUiElementsFactory uiFactory)
        {
            _uiFactory = uiFactory;
        }

        public void SetBattleData(BattleData battleData)
        {
            _battleData = battleData;

            foreach (ISpaceShip spaceShip in battleData.AllyTeam.Members)
                CreateViewForSpaceShip(spaceShip, true);

            foreach (ISpaceShip spaceShip in battleData.EnemyTeam.Members)
                CreateViewForSpaceShip(spaceShip, false);
        }

        private void CreateViewForSpaceShip(ISpaceShip spaceShip, bool isAllySide)
        {
            Vector2 screenPosition = Camera.main.WorldToScreenPoint(spaceShip.Data.Position); //TODO: refactor this to use a camera provider
            Vector2 viewSpawnOffset = isAllySide ? _viewSpawnOffset : -_viewSpawnOffset;
            HealthView healthView = _uiFactory.CreateHealthView(spaceShip, screenPosition + viewSpawnOffset, transform);
            _spaceShipToHealthViewMap.Add(spaceShip, healthView);
            spaceShip.OnDeath += OnSpaceShipDeathEventHandler;
        }

        public void Clear()
        {
            _spaceShipToHealthViewMap.Values.ToList().ForEach(view => Destroy(view.gameObject));
            _spaceShipToHealthViewMap.Clear();
        }

        private void OnSpaceShipDeathEventHandler(ISpaceShip spaceShip)
        {
            var view = _spaceShipToHealthViewMap[spaceShip];
            _spaceShipToHealthViewMap.Remove(spaceShip);
            Destroy(view.gameObject);
            spaceShip.OnDeath -= OnSpaceShipDeathEventHandler;
        }
    }
}
