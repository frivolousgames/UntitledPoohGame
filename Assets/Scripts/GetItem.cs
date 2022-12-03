using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetItem : MonoBehaviour
{
    public string type;
    public int value;

    public GameObject itemText;
    Camera cam;
    GameObject canvas;

    private void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("MainCanvas");
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other == PoohPlatformController.poohCol)
        {
            if(type == "Health")
            {
                PoohHealth.health += value;
            }
            Vector3 offset = new Vector3(0, 1, 0);
            GameObject textPrefab = Instantiate(itemText, cam.ViewportToWorldPoint(transform.parent.position).normalized + offset, Quaternion.identity, canvas.transform);
            textPrefab.GetComponentInChildren<Text>().text = "+" + value + " HEALTH";
            Destroy(transform.parent.gameObject);
        }
    }
}
