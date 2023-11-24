using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public Slider healthBar;
    public GameObject projectile;
    public Transform projectilePoint;

    public bool hasShot = false;
    public int shotDelay = 1;

    public Animator animator;

    public void Shoot()
    {
        if (hasShot == false) {
            hasShot = true;
            GameObject projectileObj = Instantiate(projectile, projectilePoint.position, Quaternion.identity);
            Rigidbody rb = projectileObj.GetComponent<Rigidbody>();

            rb.AddForce(transform.forward * 50f, ForceMode.Impulse);
            rb.AddForce(transform.up * 7, ForceMode.Impulse);

            Invoke("Reload", shotDelay);
            //StartCoroutine(ReloadProjectile());
            StartCoroutine(DestroyProjectile(projectileObj));
        }
    }

    public void Reload() {
        hasShot = false;
    }
    private IEnumerator DestroyProjectile(GameObject projectile) {
        yield return new WaitForSeconds(1);
        Destroy(projectile);
    }
    private IEnumerator ReloadProjectile()
    {
        yield return new WaitForSeconds(shotDelay);
        hasShot = false;
    }
}
