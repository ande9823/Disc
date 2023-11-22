<<<<<<< HEAD:SpaceDiscMania/Assets/Arts/EnemyAI/Enemy.cs
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
=======
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
    /*
    PatrolBehavior patrolBehavior;
    public Transform randomWaypoint;

    public void Start()
    {
        randomWaypoint.position = new Vector3(transform.position.x - Random.Range(0, 5), 0, transform.position.z - Random.Range(0, 5));

        patrolBehavior = new PatrolBehavior();
        patrolBehavior.wayPoints.Insert(0,randomWaypoint);
    }

    public void Update()
    {
        randomWaypoint.position = new Vector3(transform.position.x - Random.Range(0, 5), 0, transform.position.z - Random.Range(0, 5));
        patrolBehavior.wayPoints.Insert(0, randomWaypoint);
        patrolBehavior.agent.SetDestination(patrolBehavior.wayPoints[0].position);
    }
    */
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
>>>>>>> cecf62c90914945bf5cb6bad4192fa10e5b8bac1:SpaceDiscMania/Assets/EnemyAI/Enemy.cs
