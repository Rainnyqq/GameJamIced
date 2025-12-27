using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletDestroy : MonoBehaviour
{
    void Start()
    {

    }


    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
