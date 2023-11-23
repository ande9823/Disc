using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth = 100;
    public Slider HPbar;
    public Animator animator;

    public void SetHealth(int health)
    {
        HPbar.value = health;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        SetHealth(currentHealth);

        if (HPbar.value <= 1)
        {
            animator.SetTrigger("death");
            GetComponent<CapsuleCollider>().enabled = false;
        }
        else
        {
            HPbar.value -= damageAmount;
            animator.SetTrigger("damage");
        }
    }
}
