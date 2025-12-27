using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;

public class MobsSpawner : MonoBehaviour
{
    [SerializeField] private float _spawnTime;
    [SerializeField] private GameObject _prefab;
    [SerializeField] public float radius = 10f;

    private void Start()
    {
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        // - random.... -> Vec2d
        Vector3 origin = GameObject.FindGameObjectWithTag("Player").transform.position;
        Vector2 enemyPos = origin + Random.insideUnitSphere * radius;
        Instantiate(_prefab, enemyPos, Quaternion.identity);
        yield return new WaitForSeconds(_spawnTime);
        StartCoroutine(Spawner());
    }
}
