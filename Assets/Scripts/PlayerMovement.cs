using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float speed = 5;
    


    private bool facingRight;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        

        float _horizontal = Input.GetAxis("Horizontal");
        Movement(_horizontal);
        Flip(_horizontal);

    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void Movement(float _horizontal)
    {
        rb.velocity = new Vector2(_horizontal * speed, rb.velocity.y);
    }

    private void Flip(float _horizontal)
    {
        if (_horizontal > 0 && !facingRight || _horizontal < 0 && facingRight)
        {
            facingRight = !facingRight;

            Vector3 theScale = transform.localScale;

            theScale.x *= -1;

            transform.localScale = theScale;
        }
    }
}
