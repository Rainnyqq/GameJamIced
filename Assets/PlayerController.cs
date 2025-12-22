using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    //[SerializeField] private float acc = 1f;
    [SerializeField] private float f1 = 10.0f;
    [SerializeField] private float mass = 10.0f;
    [SerializeField] private float t = 0f;
    [SerializeField] private float nu = 0.001f;
    [SerializeField] private Vector2 acc = Vector2.zero;
    [SerializeField] private Vector2 v = Vector2.zero; 

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");


        Vector3 direction = new Vector2(horizontal, vertical).normalized;
        Vector2 f1_vec = direction * f1;
        Vector2 f2_vec = -v.normalized * mass * nu;

        Vector2 f_sum = f1_vec + f2_vec;
        acc = f_sum / mass;
        v += acc;

        Vector3 v3d = new Vector3(v.x, v.y, 0);
        transform.position += v3d;
    }
}