using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IRTest
{
    /// <summary>
    /// Simple sound effects controller for the game that contains a dictionary
    /// of clips to choose from to use.
    /// </summary>
    public class SFXController : MonoBehaviour
    {
        private Dictionary<string, AudioClip> _audioClipDictionary;
        [SerializeField] private AudioSource _audioSource;

        private void Awake()
        {
            AudioClip[] sources = Resources.LoadAll<AudioClip>(GameConstants.RESOURCE_PATH_SFX);
            _audioClipDictionary = new Dictionary<string, AudioClip>();

            foreach (AudioClip source in sources)
            {
                _audioClipDictionary.Add(source.name, source);
            }
        }

        public void PlayAudioClip(string clipID)
        {
            if (_audioClipDictionary.ContainsKey(clipID))
            {
                _audioSource.clip = _audioClipDictionary[clipID];
                _audioSource.Play();
            }
        }
    }
}
