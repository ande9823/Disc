using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowDisc : MonoBehaviour
{
    public GameObject discPrefab;
    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            Ray r = cam.ScreenPointToRay(Input.mousePosition);

            Vector3 dir = r.GetPoint(1) - r.GetPoint(0);

            GameObject disc = Instantiate(discPrefab, r.GetPoint(2), Quaternion.LookRotation(dir));

            disc.GetComponent<Rigidbody>().velocity = disc.transform.forward * 20;
            Destroy(disc, 5);
        }
    }
}
