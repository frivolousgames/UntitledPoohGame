using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PoohHealth : MonoBehaviour
{
    bool isDead;
    public UnityEvent die;

    public Slider healthBar;
    int maxHealth;
    public static int health;

    private void Awake()
    {
        maxHealth = 100;
        health = maxHealth;
    }
    private void Start()
    {
        healthBar.value = maxHealth;
    }

    private void Update()
    {
        healthBar.value = health;
        if(health > maxHealth)
        {
            health = maxHealth; 
        }
        Die();
    }

    public void Hit()
    {
        if(health >= 10)
        {
            health -= 10;
        }
        else
        {
            health = 0;
        }
    }

    void Die()
    {
        if (health < 1 && isDead == false)
        {
            isDead = true;
            die.Invoke();
            Debug.Log("Dead");
        }
    }

}
