using UnityEditor.Experimental.GraphView;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    //[SerializeField] private float acc = 1f;
    [SerializeField] private float f1 = 10.0f;
    [SerializeField] private float nu = 0.001f;
    [SerializeField] private Vector2 direction = Vector2.zero;
    [SerializeField] public float health = 3f;
    [SerializeField] public int score = 0;
    private Rigidbody2D rb2D;
    public TextMeshProUGUI scoreText;
    public Sprite normanSnowman;
    public Sprite rightSnowman;
    public Sprite leftSnowman;
    public Sprite backwardSnowman;
    public float angle;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.sprite = normanSnowman;
        //Sprite newSprite = ...;
        //sr.sprite = newSprite;
    }

    private void Update()
    {

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        direction = new Vector2(horizontal, vertical).normalized;
        if (horizontal != 0 || vertical != 0)
        {
            SpriteRenderer sr = GetComponent<SpriteRenderer>();

            angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            if (angle >= 135 || angle <= -135)
            {
                sr.sprite = leftSnowman;
            }

            if (angle >= -45 && angle <= 45)
            {
                sr.sprite = rightSnowman;
            }

            if (angle == 90)
            {
                sr.sprite = backwardSnowman;
            }

            if (angle == -90)
            {
                sr.sprite = normanSnowman;
            }
        }



        //if (direction.x == 0 & )

        //Quaternion rot = Quaternion.LookRotation(Vector2.up, direction);
        //transform.rotation = new Quaternion(0, 0, rot.z, 0);
        //transform.rotation = rot;

        //float angle = -Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        //Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        //transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 5);

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
            
            //health -= 1;
            score += 1;
            scoreText.text = "SCORE " + score.ToString();
        }
    }
}