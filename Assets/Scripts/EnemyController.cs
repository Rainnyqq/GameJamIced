using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour

{
    private Rigidbody2D rb2D;
    public GameObject player;
    public float speed;
    public Vector2 direction;
    public float force;
    SpriteRenderer zombie;
    public float iced = 0f;


    //private float distance;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb2D = GetComponent<Rigidbody2D>();
        zombie = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //distance = Vector2.Distance(transform.position, player.transform.position);
        direction = player.transform.position - transform.position;
        direction.Normalize();

        //transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        rb2D.AddForce(direction * force, ForceMode2D.Force);
        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(Vector3.forward * angle);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Bullet")
        {
            iced = 1;
            //Destroy(gameObject);
            // Change the 'color' property of the 'Sprite Renderer'
            zombie.color = new Color(0, 150, 255, 255);
            rb2D.constraints = RigidbodyConstraints2D.FreezePosition;
            
        }

        if (collision.gameObject.tag == "Player" & iced == 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(0);
        }

        if (collision.gameObject.tag == "Player" & iced == 1)
        {
            Destroy(gameObject);
        }

    }
}
