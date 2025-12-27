using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform player;
    public float bulletSpeed = 50;
    
    Vector2 lookDirection;
    float lookAngle;

    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        lookDirection = new Vector2(mousePos.x - player.position.x, mousePos.y - player.position.y);
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        Vector2 lookDirectionShort = new Vector2(lookDirection.x / 5, lookDirection.y / 5).normalized * 2;

        transform.rotation = Quaternion.Euler(0, 0, lookAngle);
        transform.position = new Vector2(player.position.x + lookDirectionShort.x, player.position.y + lookDirectionShort.y);

        if (Input.GetMouseButtonDown(0))
        {
            GameObject bulletClone = Instantiate(bullet);
            bulletClone.transform.position = transform.position;

            bulletClone.GetComponent<Rigidbody2D>().velocity = transform.right * bulletSpeed;
        }
    }
}
