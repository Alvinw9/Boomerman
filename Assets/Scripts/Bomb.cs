using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // destroy buff or debuff
        if (collision.gameObject.tag != "Player" && collision.gameObject.tag != "Wall")
        {
            Destroy(collision.gameObject);
        }

        /*if (collision.gameObject.tag == "Bomb")
        {
            Physics.IgnoreCollision(Bomb.collider, GetComponent<collider>());
        }

        if (collision.gameObject.GetComponent<Bomb>() != null)
        {

        }*/

    }

}
