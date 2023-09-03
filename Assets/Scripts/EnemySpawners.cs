using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;


public class EnemySpawners : MonoBehaviour
{
    [SerializeField] private GameObject[] _spawnPoints;
    [SerializeField] private Rigidbody2D template;
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
            Rigidbody2D newObject = Instantiate(template, GetSpawnPoint(_spawnPoints).transform);

            EnemyWalk walk = newObject.GetComponent<EnemyWalk>();

            walk.SetDirection(TakeDirection());

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

    private GameObject GetSpawnPoint(GameObject[] gameObjects)
    {
        return gameObjects[Random.Range(0, gameObjects.Length)];
    }
}
