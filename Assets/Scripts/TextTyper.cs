using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class TextTyper : MonoBehaviour
{
    Text text;
    string fillText;
    public static bool filled;

    public UnityEvent done;

    private void OnEnable()
    {
        StartCoroutine("AdderWait");
        Debug.Log("Active");
    }

    private void OnDisable()
    {
        StopAllCoroutines();
        filled = false;
        text.text = "";
    }

    private void Awake()
    {
        filled = false;
        text = GetComponent<Text>();
        //fillText = "Hello I am a frogman who\neats shit all day long. Please\nlet me eat in peace!";
    }
    IEnumerator AdderWait()
    {
        yield return new WaitForSeconds(1f);
        StringAdder();
    }

    public void StringAdder()
    {
        filled = false;
        //StartCoroutine("AddFormattedStrings");
        StartCoroutine("AddStrings");
    }

    /*IEnumerator AddFormattedStrings()
    {
        fillText = TalkTexts.speechText;
        string temp = "";
        List<string> formatted = new List<string>();
        int i = 0;
        foreach (char c in fillText)
        {
            temp += c;
            i++;
            while (temp.Length > 14)
            {
                Debug.Log(">14");
                for (int j = temp.Length - 1; j > 0; j--)
                {
                    Debug.Log(temp[j]);
                    if (temp[j].ToString() == " ")
                    {
                        foreach(char ch in temp)
                        {
                            formatted.Add(ch.ToString());
                        }
                        formatted[j] = "\n";
                        Debug.Log(temp);
                        temp = "";
                        break;
                    }
                }
            }
        }
        foreach(char cha in temp)
        {
            formatted.Add(cha.ToString());
        }
        text.text = "";
        foreach (string s in formatted)
        {
            text.text += s;
            yield return new WaitForSeconds(PlayerPrefs.GetFloat("Text Speed", .07f));
        }
        filled = true;
        done.Invoke();

    }*/

    IEnumerator AddStrings()
    {
        text.text = "";
        fillText = TalkTexts.speechText;
        int i = 0;
        int j = 0;
        foreach (char c in fillText)
        {
            
            text.text += c;
            i++;
            j++;
            if (j > 16)
            {
                if (c.ToString() == " ")
                {
                    text.text += "\n";
                    j = 0;
                }
                else if(c.ToString() == "\n")
                {
                    Debug.Log("Escaped");
                    j = 0;
                }

            }
            yield return new WaitForSeconds(PlayerPrefs.GetFloat("Text Speed", .07f));
        }
        filled = true;
        done.Invoke();
    }
}
