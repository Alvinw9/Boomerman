using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Bomb : MonoBehaviour {
    
    public GameObject explosion;
    public Bomb bombPrefab;
    public Rigidbody2D rb;
    public Tilemap tilemap;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<BoxCollider2D>();
    }

    public IEnumerator Explode(int bombRange, int explosionDelay)
    {
        yield return new WaitForSeconds(explosionDelay);

        GameObject[] bombExplosion = new GameObject[bombRange];
        GameObject[] rightExplosion = new GameObject[bombRange];
        GameObject[] leftExplosion = new GameObject[bombRange];
        GameObject[] topExplosion = new GameObject[bombRange];
        GameObject[] bottomExplosion = new GameObject[bombRange];


        for (int i = 0; i < bombRange; i++)
        {
            bombExplosion[i] = Instantiate(explosion, new Vector2(Mathf.RoundToInt(this.transform.position.x),
                                                    Mathf.RoundToInt(this.transform.position.y)), transform.rotation);
            rightExplosion[i] = Instantiate(explosion, new Vector2(Mathf.RoundToInt(this.transform.position.x + (i + 1)),
                                                    Mathf.RoundToInt(this.transform.position.y)), transform.rotation);
            leftExplosion[i] = Instantiate(explosion, new Vector2(Mathf.RoundToInt(this.transform.position.x - (i + 1)),
                                            Mathf.RoundToInt(this.transform.position.y)), transform.rotation);
            topExplosion[i] = Instantiate(explosion, new Vector2(Mathf.RoundToInt(this.transform.position.x),
                                            Mathf.RoundToInt(this.transform.position.y + (i + 1))), transform.rotation);
            bottomExplosion[i] = Instantiate(explosion, new Vector2(Mathf.RoundToInt(this.transform.position.x),
                                            Mathf.RoundToInt(this.transform.position.y - (i + 1))), transform.rotation);
        }

        for (int i = 0; i < bombRange; i++)
        {
            
            Destroy(bombExplosion[i], 0.2f);
            Destroy(rightExplosion[i], 0.2f);
            Destroy(leftExplosion[i], 0.2f);
            Destroy(topExplosion[i], 0.2f);
            Destroy(bottomExplosion[i], 0.2f);
            
        }

        Destroy(this.gameObject, 0.2f);
    }
    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // destroy buff or debuff
        if (collision.gameObject.tag != "Player" && collision.gameObject.tag != "Player2" && collision.gameObject.tag != "Wall" && collision.gameObject.tag != "Bomb")
        {
            Destroy(collision.gameObject);
        }

        if ( collision.gameObject.tag == "Bomb")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        }

        if (collision.gameObject.tag == "Wall")
        {
            tilemap.SetTile(tilemap.WorldToCell(collision.rigidbody.position), null);
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {

        // sets the mass so the bomb can be pushed
        rb = GetComponent<Rigidbody2D>();
        //rb.mass = 1;

    }

}
