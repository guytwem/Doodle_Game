using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private GameObject player;
    public Text score;
    private float currentScore;


    
    private void Update()
    {
        

        if (player.transform.position.y > currentScore)
        {
            currentScore = player.transform.position.y;
            
        }

        score.text = "Score: " + currentScore.ToString();
    }
}
