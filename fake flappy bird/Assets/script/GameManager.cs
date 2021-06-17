using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public int Score;
    public Text ScoreText;
    void Start()
    {
        Score = 0;
        ScoreText.text = Score.ToString();
    }

    
    void Update()
    {
        
    }
    public void UpdateScore()
    {
        Score++;
        ScoreText.text = Score.ToString();
    }
}
