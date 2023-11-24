using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchPad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Enemy")) {
            //other.gameObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward, ForceMode.Impulse);
        }
    }
}
