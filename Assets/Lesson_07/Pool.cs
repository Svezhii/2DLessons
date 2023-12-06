using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Pool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;

    private List<EnemyMover> _pool = new List<EnemyMover>();

    protected void Initialize(EnemyMover[] enemy)
    {
        for (int i = 0; i < _capacity; i++)
        {
            int randomIndex = Random.Range(0, enemy.Length);
            EnemyMover spawned = Instantiate(enemy[randomIndex], _container.transform);
            spawned.gameObject.SetActive(false);

            _pool.Add(spawned);
        }
    }

    protected bool TryGetEnemy(out EnemyMover result)
    {
        result = _pool.FirstOrDefault(entity => entity.gameObject.activeSelf == false);

        return result != null;
    }
}
