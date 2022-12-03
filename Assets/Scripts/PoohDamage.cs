using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PoohDamage : MonoBehaviour
{
    GameObject[] enemyWeapons;

    public UnityEvent hit;

    private void Start()
    {
        enemyWeapons = GameObject.FindGameObjectsWithTag("EnemyWeapon");
    }

    private void Update()
    {
        enemyWeapons = GameObject.FindGameObjectsWithTag("EnemyWeapon");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(enemyWeapons.Length > 0)
        {
            foreach (var weapon in enemyWeapons)
            {
                if (other.gameObject == weapon)
                {
                    hit.Invoke();
                }
            }
        }  
    }
}
