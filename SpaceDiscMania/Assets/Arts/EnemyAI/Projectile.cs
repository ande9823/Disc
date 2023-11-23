using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject impactEffect;
    public int knockback = 5;
    public float radius = 3;
    public int damageAmount = 15;

    private void OnCollisionEnter(Collision collision)
    {
        
        GameObject impact  = Instantiate(impactEffect, transform.position, Quaternion.identity);
        Destroy(impact, 2);

        if(collision.gameObject.CompareTag("Player")) {

            
            HealthBarSimple healthBar = collision.gameObject.GetComponent<HealthBarSimple>();
            healthBar.TakeDamage(damageAmount);

            /*
            Rigidbody enemy = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 difference = enemy.transform.position - transform.position;
            difference = difference.normalized * knockback;
            enemy.AddForce(difference, ForceMode.Impulse);
            */
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {


            HealthBarSimple healthBar = collision.gameObject.GetComponent<HealthBarSimple>();
            healthBar.TakeDamage(damageAmount);
        }
            /*
            Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
            foreach(Collider nearbyObject in colliders)
            {
                if(nearbyObject.tag == "Player")
                {
                    StartCoroutine(FindObjectOfType<PlayerManager>().TakeDamage(damageAmount));
                }
            }
            this.enabled = false;
            */
        }
    }
