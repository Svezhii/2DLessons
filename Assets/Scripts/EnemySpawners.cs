using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;


public class EnemySpawners : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private EnemyWalk template;
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
            EnemyWalk newObject = Instantiate(template, GetSpawnPoint(_spawnPoints));

            newObject.SetDirection(TakeDirection());

            yield return waitForSeconds;
        }
    }

    private float TakeDirection()
    {
        var randomDirection = Random.Range(0, 101);

        if (randomDirection > 50)
        {
            return -1;
        }
        else
        {
            return 1;
        }
    }

    private Transform GetSpawnPoint(Transform[] gameObjects)
    {
        return gameObjects[Random.Range(0, gameObjects.Length)];
    }
}
