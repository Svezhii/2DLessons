using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : Pool
{
    [SerializeField] private EnemyMover[] _enemyPrefabs;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _spawnInterval;

    private void Start()
    {
        Initialize(_enemyPrefabs);

        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        var waitForSeconds = new WaitForSeconds(_spawnInterval);

        while (enabled)
        {
            if(TryGetEnemy(out EnemyMover enemy))
            {
                var numberSpawnPoint = GetNumberSpawnPoint(_spawnPoints);

                SetEnemy(enemy, _spawnPoints[numberSpawnPoint].position);
            }

            yield return waitForSeconds;
        }
    }

    private int GetNumberSpawnPoint(Transform[] spawnPoints)
    {
        return Random.Range(0, spawnPoints.Length);
    }

    private void SetEnemy(EnemyMover enemy, Vector3 spawnPoint)
    {
        enemy.gameObject.SetActive(true);
        enemy.transform.position = spawnPoint;
    }
}
