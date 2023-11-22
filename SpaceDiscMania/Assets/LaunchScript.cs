using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchScript : MonoBehaviour
{
    public float launchUpSpeed = 10;
    public float launchSpeed = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered LaunchPad");

        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Player"))
        {
            Debug.Log(""+other.gameObject.name);
            Rigidbody otherRb = other.gameObject.GetComponent<Rigidbody>();
            
            otherRb.AddForce(Vector3.up *launchUpSpeed);
            otherRb.AddForce(Vector3.forward *launchSpeed);
        }
    }
}
