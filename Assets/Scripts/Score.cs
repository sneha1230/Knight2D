using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score = 0;
    public Text ScoreText;
    public static Score instance;
    private void Awake()
    {
        instance = this;
    }
    public void IncrementScore()
    {
        score++;
        ScoreText.text = "Score: " + score;
    }
}
