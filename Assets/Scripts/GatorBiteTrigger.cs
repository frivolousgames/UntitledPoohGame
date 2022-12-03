using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GatorBiteTrigger : MonoBehaviour
{
    GameObject[] sacks;

    public UnityEvent bite;

    GameObject[] finish;

    public UnityEvent setInactive;


    private void Start()
    {
        finish = GameObject.FindGameObjectsWithTag("Finish");
    }
    private void Update()
    {
        sacks = GameObject.FindGameObjectsWithTag("Sack");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (sacks != null)
        {
            foreach (GameObject s in sacks)
            {
                if (other.gameObject == s)
                {
                    bite.Invoke();
                    GatorController.target = s;
                }
            }
        }
        foreach(GameObject f in finish)
        {
            if(other.gameObject == f)
            {
                setInactive.Invoke();
            }
        }
    }
}
