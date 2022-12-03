using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElephantHeadController : MonoBehaviour
{
    public bool hitting;
    float hitWait;

    float currentFrame;
    Animator anim;

    public float cycleOffset;

    public GameObject attackCol;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        anim.SetFloat("cycleOffset", cycleOffset);
        anim.SetBool("hitting", hitting);
    }
    public void Hit()
    {
        if (hitting != true)
        {
            hitting = true;
            attackCol.SetActive(true);
            StartCoroutine("HitWait");
        }
    }

    IEnumerator HitWait()
    {
        hitWait = anim.GetCurrentAnimatorClipInfo(0)[0].clip.length - .1f;
        yield return new WaitForSeconds(hitWait);
        {
            cycleOffset = ElephantController.currentFrame;
            attackCol.SetActive(false);
            hitting = false;
        }
    }
}
