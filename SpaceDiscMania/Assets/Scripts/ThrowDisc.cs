using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThrowDisc : MonoBehaviour
{
    public GameObject discPrefab;
    public Camera cam;

    public AudioSource shoot;

    public bool hasThrown = false;
    public int throwDelay = 1;

    public Slider coolDownSlider;

    private void Start()
    {
        shoot = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (hasThrown == false) {
                hasThrown = true;
                shoot.Play();
                Ray r = cam.ScreenPointToRay(Input.mousePosition);

                Vector3 dir = r.GetPoint(1) - r.GetPoint(0);

                GameObject disc = Instantiate(discPrefab, r.GetPoint(2), Quaternion.LookRotation(dir));

                disc.GetComponent<Rigidbody>().velocity = disc.transform.forward * 40;
                StartCoroutine(DestroyDisc(disc));

                StartCoroutine(reloadCorutine());
            }
        }
    }

    private IEnumerator DestroyDisc(GameObject disc) {

        yield return new WaitForSeconds(5);
        Destroy(disc);
    }

    IEnumerator reloadCorutine()
    {
        coolDownSlider.value = 0;
        
        yield return new WaitForSeconds(throwDelay);
        coolDownSlider.value = 1;
        hasThrown = false;
    }
}
