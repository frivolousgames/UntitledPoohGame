using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootController : MonoBehaviour
{
    public GameObject powerMeter;
    public Slider meterSlider;
    public static float shotPower;

    public static bool pressed = false;

    public GameObject bullet;
    public Transform bulletSpawnPos;

    public Transform cannon;
    float shotAngle; //min 0, max 65

    public GameObject shotBlocker;

    public GameObject smoke;

    public Animator poohAnim;

    GameObject[] bulletIcons;
    int iconNum = 0;

    private void Start()
    {
        bulletIcons = GameObject.FindGameObjectsWithTag("BulletIcon");
    }
    private void Update()
    {
        shotAngle = cannon.localEulerAngles.z;
        Debug.Log("Pressed: " + pressed);
    }

    public void ButtonDown()
    {
        pressed = true;
        powerMeter.SetActive(true);
        StartCoroutine("ButtonHeld");
    }

    IEnumerator ButtonHeld()
    {
        while(pressed == true)
        {
            shotPower = Mathf.Lerp(4f, 10f, meterSlider.value);
            yield return null;
        }
    }

    public void ButtonUp()
    {
        pressed = false;
        shotBlocker.SetActive(true);
        StartCoroutine("MeterHold");
    }

    IEnumerator MeterHold()
    {
        yield return new WaitForSeconds(.5f);
        powerMeter.SetActive(false);
        Shoot();
        StartCoroutine("BlockerOff");
    }

    IEnumerator BlockerOff()
    {
        yield return new WaitForSeconds(1f);
        shotBlocker.SetActive(false);
    }

    public void Shoot()
    {
        Instantiate(bullet, bulletSpawnPos.position, new Quaternion(cannon.localRotation.x, cannon.localRotation.y, cannon.localRotation.z + .1f, cannon.rotation.w), null);
        Instantiate(smoke, bulletSpawnPos.position, cannon.rotation, null);
        poohAnim.SetTrigger("Shoot");
        bulletIcons[iconNum].SetActive(false);
        iconNum++;
    }
}
