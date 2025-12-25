using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckPointController : MonoBehaviour
{
    [SerializeField] public float level = 1.0f;



    public Transform checkpointPrefab;
    void Start()
    {
        
    }

    public GameObject playerObj;

    void Awake()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
    }


    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            level += 1;

            if (level == 3)
            {
                SceneManager.LoadScene(0);
            }
        }
    }
    

   
}
