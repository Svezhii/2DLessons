using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Coin _template;
    [SerializeField] private float _spawnInterval;

    private void Start()
    {
        StartCoroutine(SpawnObject());
    }

    private IEnumerator SpawnObject()
    {
        var waitForSeconds = new WaitForSeconds(_spawnInterval);

        while (enabled)
        {
            var numberSpawnPoint = GetNumberSpawnPoint(_spawnPoints);

            Instantiate(_template, _spawnPoints[numberSpawnPoint]);

            yield return waitForSeconds;
        }
    }

    private int GetNumberSpawnPoint(Transform[] spawnPoints)
    {
        return Random.Range(0, spawnPoints.Length);
    }
}
