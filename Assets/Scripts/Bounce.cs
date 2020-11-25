using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Rigidbody2D>().velocity.y <= 0)//bounce player
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.up * 600f);//sends player up
        }
    }
}
