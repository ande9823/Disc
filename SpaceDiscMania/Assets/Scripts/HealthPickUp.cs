using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    public GameObject Cross;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerHealthBar>().restoreHealth();
            Cross.SetActive(false);
            StartCoroutine(SetObject());
        }
    }

    IEnumerator SetObject()
    {
        yield return new WaitForSeconds(10);
        Cross.SetActive(true);
    }
}
