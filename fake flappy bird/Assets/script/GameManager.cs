using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public int Score;
    public Text ScoreText;
    public int yourScore;
    public Text YourScoreText;

    private void Awake()
    {
        
    }
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
        yourScore = Score;
        YourScoreText.text = yourScore.ToString();
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
