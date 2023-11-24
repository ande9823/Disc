using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThrowDisc : MonoBehaviour
{
    public GameObject discPrefab;
    public Camera cam;

    public bool hasThrown = false;
    public int throwDelay = 1;

    public Slider coolDownSlider;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            if(hasThrown == false) {
                hasThrown = true;

                Ray r = cam.ScreenPointToRay(Input.mousePosition);

                Vector3 dir = r.GetPoint(1) - r.GetPoint(0);

                GameObject disc = Instantiate(discPrefab, r.GetPoint(2), Quaternion.LookRotation(dir));

                disc.GetComponent<Rigidbody>().velocity = disc.transform.forward * 20;
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
        yield return new WaitForSeconds(throwDelay / 5);
        coolDownSlider.value = 1 / 5;
        yield return new WaitForSeconds(throwDelay / 5);
        coolDownSlider.value = 2 / 5;
        yield return new WaitForSeconds(throwDelay / 5);
        coolDownSlider.value = 3 / 5;
        yield return new WaitForSeconds(throwDelay / 5);
        coolDownSlider.value = 4 / 5;
        yield return new WaitForSeconds(throwDelay / 5);

        coolDownSlider.value = 1;
        hasThrown = false;
    }
}
