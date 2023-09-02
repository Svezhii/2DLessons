using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;


public class EnemySpawners : MonoBehaviour
{
    [SerializeField] private GameObject[] SpawnPoints;
    [SerializeField] private GameObject template;

    private void Start()
    {
        StartCoroutine(SpawnObject());
    }

    private IEnumerator SpawnObject()
    {
        bool isWork = true;
        var waitForTwoSeconds = new WaitForSeconds(2f);

        while (isWork)
        {
            GameObject newObject = Instantiate(template, GetSpawnPoint(SpawnPoints).transform);

            Walk walk = newObject.GetComponent<Walk>();

            walk.SetDirection(TakeDirection());

            yield return waitForTwoSeconds;
        }
    }

    private float TakeDirection()
    {
        var random = Random.Range(0, 101);

        if (random > 50)
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
