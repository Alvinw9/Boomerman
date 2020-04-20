using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosionScript : MonoBehaviour
{

    public GameObject newPlayer1;
    public GameObject newPlayer2;

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
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            PlayerMovement playerScript;

            if (player != null)
            {

                playerScript = player.GetComponent<PlayerMovement>();

                if (playerScript.hasShield)
                {
                    StartCoroutine(toggleShield(player));
                }
                else
                {
                    Destroy(collision.gameObject);
                    GameObject player1 = new GameObject();
                    player1 = Instantiate(newPlayer1, new Vector2(0, 9), transform.rotation);
                }
            }
        }
        
        else if (collision.gameObject.tag == "Player2")
        {
            GameObject player2 = GameObject.FindGameObjectWithTag("Player2");
            Player2Movement player2Script;

            if (player2 != null)
            {

                player2Script = player2.GetComponent<Player2Movement>();

                if (player2Script.hasShield)
                {
                    StartCoroutine(toggleShield(player2));
                }
                else
                {
                    Destroy(collision.gameObject);
                    GameObject playerNew2 = new GameObject();
                    playerNew2 = Instantiate(newPlayer2, new Vector2(0, 9), transform.rotation);
                }
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
