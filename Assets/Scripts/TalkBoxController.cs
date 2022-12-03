using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkBoxController : MonoBehaviour
{
    new string name;
    GameObject pic;

    public Text nameText;
    public Transform picBox;

    public GameObject[] pics;
    public Transform picSpawn;
 
    private void Start()
    {
        name = TalkScenenManager.oppName;
        //name = pics[Random.Range(0, pics.Length)].name; //Temp name
        //name = pics[1].name; //Temp name
        nameText.text = name.ToUpper();
        SetPic(name);
        
    }

    void SetPic(string name)
    {
        foreach(GameObject p in pics)
        {
            if(p.name == name)
            {
                pic = p;
                Instantiate(pic, picSpawn.position, Quaternion.identity, picBox);
            }
            else
            {
                Debug.Log("No Pic");
            }
        }
        
    }

}
