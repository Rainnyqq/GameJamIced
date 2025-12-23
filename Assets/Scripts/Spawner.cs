using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float spawnTime;
    [SerializeField] private GameObject prefab;

    private void Start()
    {
        StartCoroutine(_Spawner());
    }

    private IEnumerator _Spawner()
    {
        Instantiate(prefab);
        yield return new WaitForSeconds(spawnTime);
        StartCoroutine(_Spawner());
    }
}
