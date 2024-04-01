using Assets.Scripts.Infrastructure.Factories.UI_Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.UI;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Infrastructure.Services
{
    public class BattleUIService : IBattleUIService
    {
        private readonly IUIFactory _uiFactory;

        private BattleUI _battleUI;
        private GameObject _battleUIGameObject;

        [Inject]
        public BattleUIService(IUIFactory uiFactory)
        {
            _uiFactory = uiFactory;
        }

        public void CreateBattleUI()
        {
            (_battleUI, _battleUIGameObject) = _uiFactory.CreateBattleUI();
        }

        public void SetBattle(BattleData battleData)
        {
            _battleUI.Setup(battleData);
        }

        public void DestroyBattleUI()
        {
            _battleUI = null;
            GameObject.Destroy(_battleUIGameObject);
        }
    }
}
