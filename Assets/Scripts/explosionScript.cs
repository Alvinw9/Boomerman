using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosionScript : MonoBehaviour
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
        if (collision.gameObject.tag == "Player")
        {
            GameObject player = GameObject.Find("Player");
            PlayerMovement playerScript = player.GetComponent<PlayerMovement>();
            if (playerScript.hasShield)
            {
                StartCoroutine(toggleShield(player));
            }
            else
            {
                Destroy(collision.gameObject);
            }
        }
        
        else if (collision.gameObject.tag == "Player2")
        {
            GameObject player2 = GameObject.Find("Player2");
            Player2Movement player2Script = player2.GetComponent<Player2Movement>();
            if (player2Script.hasShield)
            {
                StartCoroutine(toggleShield(player2));
            }
            else
            {
                Destroy(collision.gameObject);
            }
        }
        
        else if ( collision.gameObject.tag == "Wall")
        {
            Destroy(collision.gameObject);
        }
    }

    private IEnumerator toggleShield(GameObject player)
    {
        if(player.tag == "Player")
        {
            PlayerMovement playerScript = player.GetComponent<PlayerMovement>();
            yield return new WaitForSeconds(0.1f);
            playerScript.hasShield = false;
        }
        else if (player.tag == "Player2")
        {
            Player2Movement playerScript = player.GetComponent<Player2Movement>();
            yield return new WaitForSeconds(0.1f);
            playerScript.hasShield = false;
        }
    }
}
