using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TreeController : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        float treeSizeY = 4.5f;// GetComponent<SpriteRenderer>().size;

        Vector3 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        Vector3 treePos = transform.position;
        if (playerPos.y > (treePos.y - treeSizeY / 2))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -1);
        } else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 1);
        }
    }
}
