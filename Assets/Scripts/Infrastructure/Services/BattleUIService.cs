using Assets.Scripts.Infrastructure.Factories.UI_Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Battles;
using Assets.Scripts.UI;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Infrastructure.Services
{
    public class BattleUIService : IBattleUIService
    {
        private readonly IUIFactory _uiFactory;

        public BattleUI BattleUI { get; private set; }
        private GameObject _battleUIGameObject;

        [Inject]
        public BattleUIService(IUIFactory uiFactory)
        {
            _uiFactory = uiFactory;
        }

        public void CreateBattleUI()
        {
            (BattleUI, _battleUIGameObject) = _uiFactory.CreateBattleUI();
        }

        public void SetBattle(Battle battle)
        {
            BattleUI.ShowBattleView(battle);
        }

        public void DestroyBattleUI()
        {
            BattleUI = null;
            GameObject.Destroy(_battleUIGameObject);
        }
    }
}
