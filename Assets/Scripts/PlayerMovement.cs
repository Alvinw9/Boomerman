using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    Vector2 movement;
    int horizontal;
    int vertical;

    public static int bombsDropped = 0; // number of bombs that exist on the map
    private int numBombs = 1; // limit to number of bombs player can create at a time
    private int bombRange = 1;
    private int explosionDelay = 3;
    private float speed = 5f;
    private bool bombPenetrate = false;
    private bool canWalkThroughWalls = false;
    private bool canMoveBombs = false;
    private bool hasShield = false;
    private bool canCreateWall = false;
    private bool stunned = false;
    private bool reverseMovement = false;

    private bool placeBomb;
    public Bomb bomb;

    private void Start()
    {
        gameObject.AddComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Dynamic;
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (!stunned)
        {
            // "Enter" key to place bomb
            if (Input.GetKeyUp(KeyCode.Return) && (bombsDropped < numBombs))
            {
                placeBomb = true;
            }
        }
    }

    private void FixedUpdate()
    {

        if (!stunned)
        {
            if (!reverseMovement)
            {
                // normal movement
                rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
            } else
            {
                // reverse movement
                rb.MovePosition(rb.position - movement * speed * Time.fixedDeltaTime);
            }

            if (placeBomb)
            {
                Bomb newBomb = Instantiate(bomb, new Vector2(Mathf.RoundToInt(rb.position.x),
                                                Mathf.RoundToInt(rb.position.y)), transform.rotation);
                ++bombsDropped;
                StartCoroutine(newBomb.GetComponent<Bomb>().Explode());
                StartCoroutine(delayBombs());
                placeBomb = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ( collision.gameObject.tag == "Movement" )
        {

            // increase speed for movement buff
            speed += 3.5f;
            Destroy(collision.gameObject);

        } else if ( collision.gameObject.tag == "MovementDebuff" )
        {

            // decrease speed for movement debuff
            speed -= 3.5f;
            Destroy(collision.gameObject);

        } else if ( collision.gameObject.tag == "SelfStun" )
        {

            // momentarily stop movement and ability to place bombs
            StartCoroutine(performSelfStun());
            Destroy(collision.gameObject);

        } else if ( collision.gameObject.tag == "ReverseMovement")
        {

            // momentarily reverse the direction of movement
            StartCoroutine(reversePlayerMovement());
            Destroy(collision.gameObject);

        } else if (collision.gameObject.tag == "IncreaseBombs")
        {
            // increases the number of bombs that can be dropped at one time
            numBombs++;
            Destroy(collision.gameObject);
        }

    }

    IEnumerator performSelfStun()
    {
        // stun for 2 seconds
        stunned = true;
        yield return new WaitForSeconds(2.0f);
        stunned = false;
    }

    IEnumerator reversePlayerMovement()
    {
        // reverse direction of movement for 3.5 seconds
        reverseMovement = true;
        yield return new WaitForSeconds(3.5f);
        reverseMovement = false;
    }

    IEnumerator delayBombs()
    {
        yield return new WaitForSeconds(4.0f);
        bombsDropped--;
    }

}
