using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelActivator : MonoBehaviour
{
    Animator anim;
    public GameObject otherPanel;

    public GameObject nextButton;

    public GameObject textBox;

    public float waitTime;

    private void OnEnable()
    {
        textBox.SetActive(true);
        anim.speed = 0f;
        StartCoroutine("PanelDelay");
    }
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void SetPanelActive()
    {
        if (TalkTexts.switchPanels == true)
        {
            otherPanel.SetActive(true);
            textBox.SetActive(false);
            anim.SetTrigger("Close");

        }
    }

    IEnumerator PanelDelay()
    {
        yield return new WaitForSeconds(waitTime);
        anim.speed = 1f;
    }

    public void CloseAnim()
    {
        gameObject.SetActive(false);
    }

    public void ActivateNextButton()
    {
        if (TextTyper.filled == true)
        {
            nextButton.SetActive(true);
        }
    }

    public void DeactivateNextButton()
    {
        nextButton.SetActive(false);
    }

}
