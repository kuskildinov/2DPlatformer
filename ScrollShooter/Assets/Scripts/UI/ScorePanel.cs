using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ScorePanel : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private PlayerInteractions plaier;
    
    private int score;    

    private void Start()
    {
        PlayerPrefs.SetInt("Score", 0);
        score = 0;
    }

    public void TakeCoin()
    { 
        score += 10;
        scoreText.text = score.ToString();
        PlayerPrefs.SetInt("Score", score);
    }   
}
