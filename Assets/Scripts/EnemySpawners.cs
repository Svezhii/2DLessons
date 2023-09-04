using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;


public class EnemySpawners : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Transform[] _target;
    [SerializeField] private EnemyWalk[] template;
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

            EnemyWalk newObject = Instantiate(template[numberSpawnPoint], _spawnPoints[numberSpawnPoint]);

            newObject.SetTarget(_target[numberSpawnPoint]);

            yield return waitForSeconds;
        }
    }

    private int GetNumberSpawnPoint(Transform[] spawnPoints)
    {
        return Random.Range(0, spawnPoints.Length);
    }
}
