using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalDamage : MonoBehaviour
{
    GameObject[] bullets;

    public int maxHealth;

    int health;

    public GameObject bloodSpurt;
    public List<GameObject> bulletHole = new List<GameObject>();

    public GameObject carcass;

    public int pointValue;

    public GameObject parentTrans;

    private void Awake()
    {
        health = maxHealth;
    }

    private void Update()
    {
        bullets = GameObject.FindGameObjectsWithTag("Bullet");
        //Debug.Log(bulletHole.Count);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(bullets != null)
        {
            foreach (GameObject bullet in bullets)
            {
                if (other.gameObject == bullet)
                {
                    if (health > 0)
                    {
                        health -= 1;

                        if (bulletHole.Count > 0)
                        {
                            int i = Random.Range(0, bulletHole.Count);
                            if (!bulletHole[i].activeInHierarchy)
                            {
                                bulletHole[i].SetActive(true);
                            }
                            Instantiate(bloodSpurt, bulletHole[i].transform.position, Quaternion.identity, bulletHole[i].transform.parent);
                            bulletHole.Remove(bulletHole[i]);
                        }
                    }
                    else
                    {
                        Instantiate(carcass, parentTrans.transform.position, Quaternion.identity, null);
                        Destroy(parentTrans);
                        ScoreController.score += pointValue;
                    }
                    bullet.SetActive(false);
                }

            }
        }       
    }
    void SetBulletHole()
    {

    }

}
