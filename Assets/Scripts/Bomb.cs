﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {
    
    public GameObject explosion;
    public Bomb bombPrefab;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<BoxCollider2D>();
    }

    public IEnumerator Explode()
    {
        yield return new WaitForSeconds(4.0f);
        GameObject rightExplosion = Instantiate(explosion, new Vector2(Mathf.RoundToInt(this.transform.position.x + 1),
                                                Mathf.RoundToInt(this.transform.position.y)), transform.rotation);
        GameObject leftExplosion = Instantiate(explosion, new Vector2(Mathf.RoundToInt(this.transform.position.x - 1),
                                        Mathf.RoundToInt(this.transform.position.y)), transform.rotation);
        GameObject topExplosion = Instantiate(explosion, new Vector2(Mathf.RoundToInt(this.transform.position.x),
                                        Mathf.RoundToInt(this.transform.position.y + 1)), transform.rotation);
        GameObject bottomExplosion = Instantiate(explosion, new Vector2(Mathf.RoundToInt(this.transform.position.x),
                                        Mathf.RoundToInt(this.transform.position.y - 1)), transform.rotation);
        Destroy(rightExplosion, 0.2f);
        Destroy(leftExplosion, 0.2f);
        Destroy(topExplosion, 0.2f);
        Destroy(bottomExplosion, 0.2f);
        Destroy(this.gameObject, 0.2f);

        PlayerMovement.bombsDropped--;
    }
    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // destroy buff or debuff
        if (collision.gameObject.tag != "Player" && collision.gameObject.tag != "Wall" && collision.gameObject.tag != "Bomb")
        {
            Destroy(collision.gameObject);
        }

        if ( collision.gameObject.tag == "Bomb")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        }

    }

}
