using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class TempMainMenu : MonoBehaviour
{

    public UnityEvent click;

    public static string sceneName;

    public void NextApplescene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ResetAllData()
    {
        PlayerPrefs.DeleteAll();
    }
}
