using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerMeter : MonoBehaviour
{
    Slider meter;

    float maxValue;

    public Image fill;
    Color minColor;
    Color maxColor;
    float r;
    float g;
    float b;

    bool pressed;

    public float meterSpeed;

    private void Awake()
    {
        meter = GetComponent<Slider>();
        minColor = Color.green;
        maxColor = Color.red;
        maxValue = 1;
    }

    private void Update()
    {
        r = Mathf.Lerp(minColor.r, maxColor.r, meter.value);
        g = Mathf.Lerp(minColor.g, maxColor.g, meter.value);
        b = Mathf.Lerp(minColor.b, maxColor.b, meter.value);
        fill.color = new Color(r, g, b, .75f);
        pressed = ShootController.pressed;
    }

    private void OnEnable()
    {
        pressed = ShootController.pressed;
        meter.value = 0;
        StartCoroutine(MeterMover());
    }

    private void OnDisable()
    {
        meter.value = 0;
    }

    IEnumerator MeterMover()
    {
        while(pressed == true)
        {
            meter.value = Mathf.PingPong(Time.time * meterSpeed, maxValue);
            //Debug.Log(meter.value);
            yield return null;
        }
    }
}
