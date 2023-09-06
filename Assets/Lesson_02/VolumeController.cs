using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeController : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private float _minVolume = 0f;
    private float _maxVolume = 1f;
    private float _recoveryRate = 0.1f;

    public IEnumerator FadeController(bool IsEnemyHouse)
    {
        float targetVolume = IsEnemyHouse ? _maxVolume : _minVolume;

        while ((IsEnemyHouse && _audioSource.volume < _maxVolume) || (IsEnemyHouse == false && _audioSource.volume > _minVolume))
        {
            float volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, _recoveryRate * Time.deltaTime);
            _audioSource.volume = volume;

            yield return null;
        }
    }
}
