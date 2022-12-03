using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeMeter : MonoBehaviour
{
    Slider lifeAmount;
    public Image fillColor;
    public Color fill;
    public Color empty;
    public int redThreshold;

    public int textThresh1;
    public int textThresh2;
    public int textThresh3;

    public Text healthText;

    private void Awake()
    {
        lifeAmount = GetComponent<Slider>();
    }

    private void Start()
    {
        healthText.text = "HEALTHY";
    }

    private void Update()
    {
        //ColorChanger();
        TextChanger();
    }

    void ColorChanger()
    {
        if (lifeAmount.value < redThreshold)
        {
            fillColor.color = empty;
        }
        else
        {
            fillColor.color = fill;
        }
    }

    private void TextChanger()
    {
        if(lifeAmount.value > textThresh1)
        {
            healthText.text = "HEALTHY";
        }
        else if(lifeAmount.value >= textThresh2 && lifeAmount.value <= textThresh1)
        {
            healthText.text = "OKAY";
        }
        else if (lifeAmount.value >= textThresh3 && lifeAmount.value <= textThresh2)
        {
            healthText.text = "UH OH";
        }
        else
        {
            healthText.text = "AIDS";
        }
    }
}
