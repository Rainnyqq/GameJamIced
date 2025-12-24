using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    //[SerializeField] private float acc = 1f;
    [SerializeField] private float f1 = 10.0f;
    [SerializeField] private float nu = 0.001f;
    [SerializeField] private Vector2 direction = Vector2.zero;
    [SerializeField] public float health = 3f;
    private Rigidbody2D rb2D;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        direction = new Vector2(horizontal, vertical).normalized;

        Vector2 f1_vec = direction * f1;
        Vector2 f2_vec = -rb2D.velocity.normalized * rb2D.mass * nu;

        rb2D.AddForce(f1_vec, ForceMode2D.Force);
        //rb2D.AddForce(f2_vec, ForceMode2D.Force);

        //Vector2 f_sum = f1_vec + f2_vec;
        //acc = f_sum / mass;
        //v += acc;

        //Vector3 v3d = new Vector3(v.x, v.y, 0);
        //transform.position += v3d;
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            health -= 1;
        }
    }
}