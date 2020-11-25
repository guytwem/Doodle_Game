using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delete : MonoBehaviour
{
    public GameObject player;
    public GameObject platformPrefab;
    private GameObject myPlatform;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        myPlatform = (GameObject)Instantiate(platformPrefab, new Vector2(Random.Range(-5.5f, 5.5f), player.transform.position.y + 
            (14 + Random.Range(0.5f, 1f))), Quaternion.identity);//instantiantes new platforms infront of player
        Destroy(collision.gameObject); // destroys platforms below player
    }
}
