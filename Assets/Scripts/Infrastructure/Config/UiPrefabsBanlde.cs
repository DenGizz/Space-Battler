using UnityEngine;

namespace Assets.Scripts.Infrastructure.Config
{
    [CreateAssetMenu(fileName = "UiPrefabsBanle", menuName = "Bandles/UiPrefabsBandle")]
    public class UiPrefabsBanlde : ScriptableObject
    {
        public GameObject MainMenuUIPrefab => _mainMenuUIPrefab;
        public GameObject BattleUIPrefab => _battleUIPrefab;
        public GameObject WeaponDescriptionRowViewPrefab => _weaponDescriptionRowViewPrefab;
        public GameObject WeaponSelectionPanelPrefab => _weaponSelectionPanelPrefab;
        public GameObject SpaceShipSelectionPanelPrefab => _spaceShipSelectionPanelPrefab;
        public GameObject SpaceShipDescriptionRowViewPrefab => _spaceShipDescriptionRowViewPrefab;
        public GameObject PauseResumeUIPrefab => _pauseResumeUIPrefab;
        public GameObject WinnerUi => _winnerUiPrefab;

        [SerializeField] private GameObject _mainMenuUIPrefab;
        [SerializeField] private GameObject _battleUIPrefab;
        [SerializeField] private GameObject _pauseResumeUIPrefab;
        [SerializeField] private GameObject _winnerUiPrefab;

        [SerializeField] private GameObject _weaponDescriptionRowViewPrefab;
        [SerializeField] private GameObject _weaponSelectionPanelPrefab;
        [SerializeField] private GameObject _spaceShipSelectionPanelPrefab;
        [SerializeField] private GameObject _spaceShipDescriptionRowViewPrefab;

    }
}