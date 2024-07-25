using Assets.Scripts.Infrastructure.Core.Services.AssetProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Core.Services
{
    public class AudioPlayer : IAudioPlayer
    {
        public float NormalizedMasterVolume
        {
            get => _audioSource.volume;
            set => _audioSource.volume = Mathf.Clamp01(value);
        }

        private readonly IAssetsProvider _assetsProvider;
        private readonly ICoroutineRunner _coroutineRunner;

        private GameObject _audioGameObject;
        private AudioSource _audioSource;
        private Coroutine _audioFadeCoroutine;

        public AudioPlayer(IAssetsProvider assetsProvider, ICoroutineRunner coroutineRunner)
        {
            _assetsProvider = assetsProvider;
            _coroutineRunner = coroutineRunner;
        }

        public void Initialize()
        {
            _audioGameObject = new GameObject("Audio");
            GameObject.DontDestroyOnLoad(_audioGameObject);
            _audioSource = _audioGameObject.AddComponent<AudioSource>();
            _audioSource.volume = 0.5f;
        }

        public void UnmuteMainMenuMusic()
        {
            if (!_audioSource.isPlaying)
                PlayMainMenuMusic();

            FadeInVolume();
        }

        public void MuteMainMenuMusic()
        {
            FadeOutVolume();
        }

        private void PlayMainMenuMusic()
        {
            _audioSource.loop = true;
            _audioSource.clip = _assetsProvider.GetMainMenuMusic();
            _audioSource.Play();
        }

        private void FadeInVolume()
        {
            if (_audioFadeCoroutine != null)
                _coroutineRunner.StopCoroutine(_audioFadeCoroutine);

            _audioFadeCoroutine = _coroutineRunner.FadeValue(
                () => NormalizedMasterVolume,
                (volume) => NormalizedMasterVolume = volume,
                0.5f, 1.5f);
        }

        private void FadeOutVolume() 
        {
            if (_audioFadeCoroutine != null)
                _coroutineRunner.StopCoroutine(_audioFadeCoroutine);

            _audioFadeCoroutine =_coroutineRunner.FadeValue(
                () => NormalizedMasterVolume,
                (volume) => NormalizedMasterVolume = volume,
                0, 1.5f);
        }
    }
}
