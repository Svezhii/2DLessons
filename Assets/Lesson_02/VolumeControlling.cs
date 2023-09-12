using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HouseAlarm))]
public class VolumeControlling : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private HouseAlarm _houseAlarm;
    private Coroutine _fadeCorutine;
    private float _minVolume = 0f;
    private float _maxVolume = 1f;
    private float _recoveryRate = 0.1f;

    private void Start()
    {
        _houseAlarm = GetComponent<HouseAlarm>();
    }

    public void StartVolumeChangingCorutine()
    {
        if (_fadeCorutine != null)
        {
            StopCoroutine(_fadeCorutine);
        }

        _fadeCorutine = StartCoroutine(FadeController());
    }

    public IEnumerator FadeController()
    {
        float targetVolume = _houseAlarm.IsEnemyInside ? _maxVolume : _minVolume;

        while (_audioSource.volume != targetVolume)
        {
            Debug.Log("true");

            float volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, _recoveryRate * Time.deltaTime);
            _audioSource.volume = volume;

            yield return null;
        }
    }
}
