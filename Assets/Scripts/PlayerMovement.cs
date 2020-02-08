using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    Vector2 movement;
    int horizontal;
    int vertical;

    private int numBombs = 1;
    private int bombRange = 1;
    private int explosionDelay = 3;
    private float speed = 5f;
    private bool bombPenetrate = false;
    private bool canWalkThroughWalls = false;
    private bool canMoveBombs = false;
    private bool hasShield = false;
    private bool canCreateWall = false;
    private bool stunned = false;

    private bool placeBomb;
    public GameObject bomb;

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
            if (Input.GetKeyUp("space"))
            {
                placeBomb = true;
            }
        }
    }

    private void FixedUpdate()
    {

        if (!stunned)
        {
            // Movement
            rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);

            if (placeBomb)
            {
                GameObject newBomb = Instantiate(bomb, new Vector2(Mathf.RoundToInt(rb.position.x),
                                                Mathf.RoundToInt(rb.position.y)), transform.rotation);
                Destroy(newBomb, 2);
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

        }
    }

    IEnumerator performSelfStun()
    {
        stunned = true;
        yield return new WaitForSeconds(2.0f);
        stunned = false;
    }
}
