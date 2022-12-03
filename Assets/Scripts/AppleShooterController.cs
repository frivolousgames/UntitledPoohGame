using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AppleShooterController : MonoBehaviour
{

    public GameObject[] bullets;
    int bulletAmount;
    GameObject lastBullet;

    public float endWaitTime;

    public static bool roundWon;
    public static bool roundLost;

    public static int syringes;

    private void Awake()
    {
        //PlayerPrefs.SetInt("AppleScene", 1); //temp scene reset  
        syringes = 0;
        roundWon = false;
        roundLost = false;
    }

    private void Start()
    {
        int sceneNum = PlayerPrefs.GetInt("AppleScene", 1);
        var currentScene = PlayerPrefs.GetString("AppleScene", "Apple_" + sceneNum.ToString());

        SceneManager.LoadScene(currentScene, LoadSceneMode.Additive);
        Debug.Log(currentScene);
        PlayerPrefs.SetInt("AppleScene", sceneNum + 1); //Temp setting
        Debug.Log(sceneNum);

        bulletAmount = GameObject.FindGameObjectsWithTag("BulletIcon").Length;
    }

    private void Update()
    {
        bullets = GameObject.FindGameObjectsWithTag("Bullet");
        
        if(bullets.Length == bulletAmount)
        {
            if(lastBullet == null)
            {
                lastBullet = bullets[bullets.Length - 1];
                StartCoroutine("EndWait");
            }           
        }
    }

    IEnumerator EndWait()
    {
        yield return new WaitForSeconds(endWaitTime);
        if(roundWon == false && roundLost == false)
        {
            roundLost = true;
            Debug.Log("LOST");
        }
    }

    //TEMP
    public void NextScene()
    {
        int i = PlayerPrefs.GetInt("AppleScene", 1);
        PlayerPrefs.SetInt("AppleScene", i + 1);
        //SceneManager.UnloadScene()
        //SceneManager.UnloadSceneAsync(PlayerPrefs.GetString("AppleScene", "Apple_" + sceneNum.ToString()));
        SceneManager.LoadScene("AppleShooter");
    }

    public void Retry()
    {
        SceneManager.LoadScene("AppleShooter");
    }

    public void Quit()
    {
        SceneManager.LoadScene("TempMenu");
    }
}
