using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public int enemyHP = 100;
    public GameObject projectile;
    public Transform projectilePoint;

    public bool hasShot = false;
    public int shotDelay = 5;

    public Animator animator;

    public void Shoot()
    {
        if (hasShot == false) {
            hasShot = true;
            GameObject projectileObj = Instantiate(projectile, projectilePoint.position, Quaternion.identity);
            Rigidbody rb = projectileObj.GetComponent<Rigidbody>();

            rb.AddForce(transform.forward * 30f, ForceMode.Impulse);
            rb.AddForce(transform.up * 7, ForceMode.Impulse);

            Invoke("Reload", shotDelay);
            StartCoroutine(DestroyProjectile(projectileObj));
        }
    }

    public void Reload() {
        hasShot = false;
    }
    private IEnumerator DestroyProjectile(GameObject projectile) {
        yield return new WaitForSeconds(5);
        Destroy(projectile);
    }

    public void TakeDamage(int damageAmount)
    {
        enemyHP -= damageAmount;
        if(enemyHP <= 0)
        {
            animator.SetTrigger("death");
            GetComponent<CapsuleCollider>().enabled = false;
        }
        else
        {
            animator.SetTrigger("damage");
        }
    }
}
