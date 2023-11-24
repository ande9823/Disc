using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    public GameObject player;
    public GameObject respawn;
    public Slider HPBar;

    public int maxHealth = 100;
    public int currentHealth = 100;

    private void Update()
    {
        if (currentHealth < 0)
        {
            Restart();
        }
        if(transform.position.y < -10) 
        {
            Restart();
        }
    }

    void Awake()
    {
        currentHealth = maxHealth;
        HPBar.value = maxHealth;
    }

    public void SetMaxHealth(int health)
    {
        HPBar.maxValue = health;
        HPBar.value = health;
    }


    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (HPBar.value < 0)
        {
            player.transform.position = respawn.transform.position;
        }
        else
        {
            HPBar.value -= damageAmount;
        }
    }

    public void Restart()
    {
        player.SetActive(false);
        player.transform.position = respawn.transform.position;
        currentHealth = 100;
        HPBar.value = 100;
        player.SetActive(true);
    }
}
