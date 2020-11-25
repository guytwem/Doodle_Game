using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float speed = 5;

    public float timeInAir = 0f;
    public float deathTimer = 5f;



    #region Game over screen
    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject restart;
    [SerializeField] private GameObject mainMenu;
    #endregion

    Rigidbody2D rb;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;//game time is normal
        rb = GetComponent<Rigidbody2D>();//get rigidbody
        anim = GetComponent<Animator>();//get animator

        //setting game over screen off on start
        gameOver.SetActive(false);
        restart.SetActive(false);
        mainMenu.SetActive(false);

    }


    private void FixedUpdate()
    { 

        float _horizontal = Input.GetAxis("Horizontal");//gets horizontal float
        Movement(_horizontal);

    }
    // Update is called once per frame
    void Update()
    {
        //for animator to check if player is falling then play animation
        if(rb.velocity.y < 0)
        {
            anim.SetBool("isFalling", true);
        }
        else
        {
            anim.SetBool("isFalling", false);
        }
        
        //if player falls for long enough than player has died
        if (rb.velocity.y < -20)
        {
            PlayerDied();
        }

    }

    //sets game over screen active and stops game time
    private void PlayerDied()
    {
        gameOver.SetActive(true);
        restart.SetActive(true);
        mainMenu.SetActive(true);
        Time.timeScale = 0;
    }
    
    private void Movement(float _horizontal)
    {
        rb.velocity = new Vector2(_horizontal * speed, rb.velocity.y);//player movement
    }

    
}
