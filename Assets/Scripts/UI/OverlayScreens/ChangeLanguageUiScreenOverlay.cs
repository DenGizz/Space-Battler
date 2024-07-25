using Assets.Scripts.Infrastructure.Localization;
using Assets.Scripts.UI.OverlayScreens;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ChangeLanguageUiScreenOverlay : UiScreenOverlay
{
    [SerializeField] private Button _enLanguageButton;
    [SerializeField] private Button _uaLanguageButton;

    private ILocalizationService _localizationService;

    [Inject]
    public void Construct(ILocalizationService localizationService)
    {
        _localizationService = localizationService;
    }

    private void Awake()
    {
        _enLanguageButton.onClick.AddListener(() => SetLanguage(LanguageKey.EN));
        _uaLanguageButton.onClick.AddListener(() => SetLanguage(LanguageKey.UA));
    }

    private void OnDestroy()
    {
        _enLanguageButton.onClick.RemoveAllListeners();
        _uaLanguageButton.onClick.RemoveAllListeners();
    }

    private void SetLanguage(LanguageKey key)
    {
        _localizationService.SelectedLanguage = key;
    }
}
