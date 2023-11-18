using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour
{
    private int score;
    private Text scoreText;
    private void Start()
    {
        score = PlayerPrefs.GetInt("Score");
        scoreText = GetComponent<Text>();
        scoreText.text = score.ToString();
    }
}
