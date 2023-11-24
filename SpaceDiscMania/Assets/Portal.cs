using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject LJSpawnPoint;
    public GameObject BBSpawnPoint;

    public GameObject BBPortal;
    public GameObject LJPortal;

    private void OnTriggerEnter(Collider collision)
    {
        if (this.gameObject == BBPortal)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                collision.gameObject.SetActive(false);
                collision.gameObject.transform.position = LJSpawnPoint.transform.position;
                collision.gameObject.SetActive(true);
            }
        }
        else 
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                collision.gameObject.SetActive(false);
                collision.gameObject.transform.position = BBSpawnPoint.transform.position;
                collision.gameObject.SetActive(true);
            }
        }
    }
}
