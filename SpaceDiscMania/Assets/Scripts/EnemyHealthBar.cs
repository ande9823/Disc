using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using TMPro.Examples;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth = 100;
    public Slider HPbar;
    public Animator animator;

    public GameObject SpilMangaer;

    public void SetHealth(int health)
    {
        HPbar.value = health;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        SetHealth(currentHealth);

        if (currentHealth < 0)
        {
            currentHealth = 0;
        }

        if (HPbar.value <= 1)
        {

            animator.SetTrigger("death");
            //GetComponent<CapsuleCollider>().enabled = false;
            if (currentHealth == 0)
            {
                SpilMangaer.GetComponent<GameManager>().enemykilstat(); 
                Debug.Log("OneDown!");
            }
        }
        else
        {
            HPbar.value -= damageAmount;
            animator.SetTrigger("damage");
        }
    }
}
