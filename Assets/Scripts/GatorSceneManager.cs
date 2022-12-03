using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GatorSceneManager : MonoBehaviour
{

    public static int currentLevel;
    bool chapter1;
    //Obstacles
    public GameObject crossHairs;
    public GameObject gatorSpawn;
    public GameObject fishSpawn;
    public GameObject postSpawn;


    //Gators
    public static int gatorAmount;
    public static float gatorWait;

    //Fish
    public static bool isFish;
    public static float fishWait;

    //Crosshairs
    public static bool isCross;
    public static float cMoveSpeed;

    //Posts
    public static bool isPost;
    public static float pSpawnDelay;
    public static float pLifeTime;

    //Game Over
    public static bool die;
    bool dead;
    public GameObject screenSpatter;

    private void Awake()
    {
        currentLevel = PlayerPrefs.GetInt("GatorScene", 1);
        string c1 = PlayerPrefs.GetString("GatorChapter1", "true");
        if (c1 == "true")
        {
            chapter1 = true;
        }
        else
        {
            chapter1 = false;
        }

        SetScene(currentLevel);
        StartCoroutine(SpawnPause());//TEMP
    }

    private void Update()
    {
        GameOver();
    }

    void SetScene(int sceneNum)
    {
        switch (sceneNum)
        {
            case 1:
                SetSceneObstacles(2, 4, 8, false, 3, false, 3, false, 4, 1.8f); //init 2, 4, 8, 3, 3, 3.5, 1.8
                break;
            case 2:
                SetSceneObstacles(2, 4, 8, false, 3, false, 3, false, 4, 1.8f);
                break;
            case 3:
                SetSceneObstacles(2, 4, 8, false, 3, false, 3, false, 4, 1.8f);
                break;
            case 4:
                SetSceneObstacles(2, 4, 8, false, 3, false, 3, false, 4, 1.8f);
                break;
            case 5:
                SetSceneObstacles(2, 4, 8, false, 3, false, 3, false, 4, 1.8f);
                break;
            case 6:
                SetSceneObstacles(2, 4, 8, false, 3, false, 3, false, 4, 1.8f);
                break;
            case 7:
                SetSceneObstacles(2, 4, 8, false, 3, false, 3, false, 4, 1.8f);
                break;
            case 8:
                SetSceneObstacles(2, 4, 8, false, 3, false, 3, false, 4, 1.8f);
                break;
            case 9:
                SetSceneObstacles(2, 4, 8, false, 3, false, 3, false, 4, 1.8f);
                break;
            case 10:
                SetSceneObstacles(2, 4, 8, false, 3, false, 3, false, 4, 1.8f);
                break;
            case 11:
                SetSceneObstacles(2, 4, 8, false, 3, false, 3, false, 4, 1.8f);
                break;
            case 12:
                SetSceneObstacles(2, 4, 8, false, 3, false, 3, false, 4, 1.8f);
                break;
            case 13:
                SetSceneObstacles(2, 4, 8, false, 3, false, 3, false, 4, 1.8f);
                break;
            case 14:
                SetSceneObstacles(2, 4, 8, false, 3, false, 3, false, 4, 1.8f);
                break;
            case 15:
                SetSceneObstacles(2, 4, 8, false, 3, false, 3, false, 4, 1.8f);
                break;
            case 16:
                SetSceneObstacles(2, 4, 8, false, 3, false, 3, false, 4, 1.8f);
                break;
            case 17:
                SetSceneObstacles(2, 4, 8, false, 3, false, 3, false, 4, 1.8f);
                break;
            case 18:
                SetSceneObstacles(2, 4, 8, false, 3, false, 3, false, 4, 1.8f);
                break;
            case 19:
                SetSceneObstacles(2, 4, 8, false, 3, false, 3, false, 4, 1.8f);
                break;
            case 20:
                SetSceneObstacles(2, 4, 8, false, 3, false, 3, false, 4, 1.8f);
                break;
            default:
                SetSceneObstacles(2, 4, 8, false, 3, false, 3, false, 4, 1.8f);
                break;
                //(.5, 2) - last level
        }
        
    }

    void SetSceneObstacles(float gMin, float gMax, int gAmount, bool _isFish, float fWait, bool _isCross, float cSpeed, bool _isPost, float pSDelay, float pLife)
    {
        gatorWait = Random.Range(gMin, gMax);
        gatorAmount = gAmount;

        GatorSpawnController.sMin = gMin;
        GatorSpawnController.sMax = gMax;

        isFish = _isFish;
        fWait = fishWait;

        isCross = _isCross;
        cMoveSpeed = cSpeed;

        isPost = _isPost;
        pSpawnDelay = pSDelay;
        pLifeTime = pLife;
    }

    void GameOver()
    {
        if(dead == false)
        {
            if(die == true)
            {
                dead = true;
                screenSpatter.SetActive(true);
                GatorSpawnController.isSpawning = false;
                FishSpawner.isSpawning = false;
                postSpawn.SetActive(false);
                crossHairs.SetActive(false);
                if (currentLevel == 10 && chapter1 == true)
                {
                    PlayerPrefs.SetString("GatorChapter1", "false");
                    int i = PlayerPrefs.GetInt("GatorScene", 1);
                    PlayerPrefs.SetInt("GatorScene", i + 1);
                    //NextScene
                }
                else if(currentLevel == 20)
                {
                    //NextScene
                }
                else
                {
                    int i = PlayerPrefs.GetInt("GatorScene", 1);
                    PlayerPrefs.SetInt("GatorScene", i + 1);
                }
            }
        }
    }

    //TEMP
    IEnumerator SpawnPause()
    {
        
        yield return new WaitForSeconds(5f);
        fishSpawn.SetActive(true);
        yield return new WaitForSeconds(5f);
        postSpawn.SetActive(true);
        yield return new WaitForSeconds(5f);
        crossHairs.SetActive(true);

    }

    public void Quit()
    {
        SceneManager.LoadScene("TempMenu");
    }

}
