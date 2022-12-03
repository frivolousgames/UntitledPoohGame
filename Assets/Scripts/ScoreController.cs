using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public static int score;

    public Text scoreText;

    private void Awake()
    {
        score = 0;
    }

    private void Start()
    {
        scoreText.text = score.ToString();
    }

    private void Update()
    {
        scoreText.text = score.ToString();
    }

}
