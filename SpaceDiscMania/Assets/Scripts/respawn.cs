using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawn : MonoBehaviour
{
    public float threshold;


    public void Update()
    {
        if (transform.position.y < threshold)
        {
            transform.position = new Vector3(0, 0, 0);


        }
    }
}

