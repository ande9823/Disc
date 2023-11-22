<<<<<<< HEAD:SpaceDiscMania/Assets/Arts/EnemyAI/Projectile.cs
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

        if(collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Player")) {
            Rigidbody enemy = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 difference = enemy.transform.position - transform.position;
            difference = difference.normalized * knockback;
            enemy.AddForce(difference, ForceMode.Impulse);
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
=======
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
        Debug.Log("Projectile collision");

        GameObject impact  = Instantiate(impactEffect, transform.position, Quaternion.identity);
        Destroy(impact, 2);

        if(collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Player")) {
            Debug.Log(""+collision.gameObject.name);
            
            Rigidbody enemy = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 difference = enemy.transform.position - this.transform.position;
            difference = difference.normalized * knockback;
            enemy.AddForce(difference, ForceMode.Impulse);
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
>>>>>>> cecf62c90914945bf5cb6bad4192fa10e5b8bac1:SpaceDiscMania/Assets/EnemyAI/Projectile.cs
