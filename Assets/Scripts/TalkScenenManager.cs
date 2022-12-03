using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TalkScenenManager : MonoBehaviour
{
    public static string oppName;
    public GameObject[] opp;

    public GameObject poohPanel;
    public GameObject oppPanel;

    string nextScene;

    private void Awake()
    {
        //oppName = PlayerPrefs.GetString("TalkName", "Piggles"); //Actual name//
        oppName = "Eeyore"; //Temporary name//

        PlayerPrefs.SetFloat("Text Speed", .03f);
        foreach(GameObject o in opp)
        {
            if(o.name == oppName)
            {
                o.SetActive(true);
            }
        }
        

    }
    public void LoadNextLevel()
    {
        if(TalkTexts.nextScene == true)
        {
            if (oppPanel.activeInHierarchy)
                {
                    oppPanel.SetActive(false);
                }
            if (poohPanel.activeInHierarchy)
                {
                    poohPanel.SetActive(false);
                }
            nextScene = PlayerPrefs.GetString("nextScene", "AppleShooter");
            //PlayerPrefs.SetString("nextScene", )
            SceneManager.LoadScene(nextScene);
        }
        
    }

    

    
}
