using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distance : MonoBehaviour
{
    public GameObject entrance;
    Vector2 newPos;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, entrance.transform.position) >= 300)
        {
            newPos = transform.position;
            transform.position = newPos;
        }
    }
}
