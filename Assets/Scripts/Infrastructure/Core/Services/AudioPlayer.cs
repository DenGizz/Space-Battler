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

        private GameObject _audioGameObject;
        private AudioSource _audioSource;

        public AudioPlayer(IAssetsProvider assetsProvider)
        {
            _assetsProvider = assetsProvider;
        }

        public void Initialize()
        {
            _audioGameObject = new GameObject("Audio");
            GameObject.DontDestroyOnLoad(_audioGameObject);
            _audioSource = _audioGameObject.AddComponent<AudioSource>();
        }

        public void PlayMainMenuMusic()
        {
            _audioSource.loop = true;
            _audioSource.clip = _assetsProvider.GetMainMenuMusic();
            _audioSource.Play();
        }

        public void StopMainMenuMusic()
        {
            _audioSource.loop = false;
            _audioSource.clip = null;
           _audioSource.Stop();
        }
    }
}
