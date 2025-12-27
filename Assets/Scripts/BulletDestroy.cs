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
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        float dX = transform.position.x - player.transform.position.x;
        float dY = transform.position.y - player.transform.position.y;
        if (dX > 100 || dY > 100 || dX < -100 || dY < -100)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
