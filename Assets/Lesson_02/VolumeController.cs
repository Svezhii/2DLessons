using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeController : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private float _minVolume = 0f;
    private float _maxVolume = 1f;
    private float _recoveryRate = 0.1f;

    public IEnumerator FadeUp()
    {
        while(enabled)
        {
            float volume = Mathf.MoveTowards(_audioSource.volume, _maxVolume, _recoveryRate * Time.deltaTime);
            _audioSource.volume = volume;

            yield return null;
        }
    }

    public IEnumerator FadeDown()
    {
        while(_audioSource.volume > 0)
        {
            float volume = Mathf.MoveTowards(_audioSource.volume, _minVolume, _recoveryRate * Time.deltaTime);
            _audioSource.volume = volume;

            yield return null;
        }
    }
}
