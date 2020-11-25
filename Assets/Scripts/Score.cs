using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private GameObject player;
    public Text score;
    public Text highScore;
    private float currentScore;

    

    private void Start()
    {
        highScore.text = "High Score: " + PlayerPrefs.GetFloat("HighScore", 0).ToString();//puts the best highscore on the screen
        
    }

    private void Update()
    {


        if (player.transform.position.y > currentScore)
        {
            currentScore = player.transform.position.y;

           // score is players highest y position

        }

        score.text = "Score: " + currentScore.ToString(); // sets score to a string 
        if(currentScore > PlayerPrefs.GetFloat("HighScore", 0))
        {
            PlayerPrefs.SetFloat("HighScore", currentScore);
            highScore.text = "High Score: " + currentScore.ToString();
        }
        
    }
}
