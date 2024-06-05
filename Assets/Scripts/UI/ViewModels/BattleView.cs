using System.Collections.Generic;
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

        private List<HealthView> _healthViews = new List<HealthView>();

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
            _healthViews.Add(healthView);
        }

        public void Clear()
        {
            _healthViews.ForEach(view => Destroy(view.gameObject));
            _healthViews.Clear();
        }
    }
}
