using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Experimental.AI;

public class RandomWaypoint : MonoBehaviour
{
    public Vector3 newPosition;

    public void UpdateWaypoint() 
    {
        newPosition = new Vector3(transform.position.x + Random.Range(-10, 10), transform.position.y, transform.position.z + Random.Range(-10, 10));
        NavMeshHit hit;
        if(NavMesh.SamplePosition(newPosition, out hit, 10f, NavMesh.AllAreas))
        {
            transform.position = hit.position;
        }
    }
}
