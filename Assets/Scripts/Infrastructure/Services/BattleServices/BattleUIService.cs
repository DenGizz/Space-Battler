using Assets.Scripts.Infrastructure.Factories.UI_Factories;
using Assets.Scripts.Battles;
using Assets.Scripts.UI;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace Assets.Scripts.Infrastructure.Services
{
    public class BattleUIService : IBattleUiService
    {
        private readonly IUiFactory _uiFactory;

        public BattleUI BattleUi { get; private set; }
        private GameObject _battleUiGameObject;

        [Inject]
        public BattleUIService(IUiFactory uiFactory)
        {
            _uiFactory = uiFactory;
        }

        public void CreateBattleUi()
        {
            (BattleUi, _battleUiGameObject) = _uiFactory.CreateBattleUi();

        }

        public void SetBattle(Battle battle)
        {
            BattleUi.ShowBattleView(battle);
        }

        public void DestroyBattleUi()
        {
            BattleUi = null;
            Object.Destroy(_battleUiGameObject);
        }
    }
}
