using Assets.Scripts.Battles;
using Assets.Scripts.Infrastructure.Factories.UI_Factories;
using Assets.Scripts.UI.BattleUI;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace Assets.Scripts.Infrastructure.Services.BattleServices
{
    public class BattleUIService : IBattleUiService
    {
        private readonly IUiElementsFactory _uiFactory;

        public BattleUI BattleUi { get; private set; }
        private GameObject _battleUiGameObject;

        [Inject]
        public BattleUIService(IUiElementsFactory uiFactory)
        {
            _uiFactory = uiFactory;
        }

        public void CreateBattleUi()
        {
            (BattleUi, _battleUiGameObject) = _uiFactory.CreateBattleUi();
        }

        public void SetBattle(BattleData battleData)
        {
            BattleUi.ShowBattleView(battleData);
        }

        public void DestroyBattleUi()
        {
            BattleUi = null;
            Object.Destroy(_battleUiGameObject);
        }
    }
}
