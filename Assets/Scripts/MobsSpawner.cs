using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobsSpawner : MonoBehaviour
{
    [SerializeField] private float _spawnTime;
    [SerializeField] private GameObject _prefab;

    private void Start()
    {
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        Instantiate(_prefab);
        yield return new WaitForSeconds(_spawnTime);
        StartCoroutine(Spawner());
    }
}
