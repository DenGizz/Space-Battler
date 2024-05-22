using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.ScriptableObjects.ResourceBundles
{
    [CreateAssetMenu(fileName = "UiResourcesBundle", menuName = "ScriptableObjects/ResourceBundles/UiResourcesBundle")]
    public class UiResourcesBundle : ScriptableObject
    {
        public GameObject MainMenuPrefab => _mainMenuPrefab;
        public GameObject SandboxModeUiPrefab => _sandboxModeUiPrefab;

        [SerializeField] private GameObject _mainMenuPrefab;
        [SerializeField] private GameObject _sandboxModeUiPrefab;
    }
}
