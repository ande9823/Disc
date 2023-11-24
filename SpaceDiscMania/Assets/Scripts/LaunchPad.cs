using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchPad : MonoBehaviour
{
    public float originalGravity = -15.0f; //20 in inspector

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
            Debug.Log("Player on LaunchPad");
            //other.gameObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward, ForceMode.Impulse);
            other.transform.position += Vector3.forward * Time.deltaTime * 10;
            GameObject player = other.gameObject;
            player.GetComponent<StarterAssets.FirstPersonController>().JumpHeight = 10;
            StartCoroutine(ResetGravity(player));

        }
    }

    private IEnumerator ResetGravity(GameObject obj) {

        yield return new WaitForSeconds(5);
        obj.GetComponent<StarterAssets.FirstPersonController>().JumpHeight = 1.2f;
    }
}
