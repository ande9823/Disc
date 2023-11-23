using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarSimple : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public Slider slider;
    public Animator animator;
    public GameObject respawn;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        slider.value = maxHealth;
    }


    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }
    void Update()
    {
        if (currentHealth == 0)
        {
            die();
        }
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        SetHealth(currentHealth);

        if (slider.value <= 0)
        {
            animator.SetTrigger("death");
            die();
            GetComponent<CapsuleCollider>().enabled = false;
        }
        else
        {
            slider.value -= damageAmount;
            animator.SetTrigger("damage");
        }
    }

    public void die()
    {
        if(this.gameObject.tag != "Player")
        {
            animator.SetTrigger("death");
            Destroy(this.gameObject);
        }
        else if (this.gameObject.tag == "Player")
        {
            this.gameObject.transform.position = respawn.transform.position;
        }
    }
}
