using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    SpriteRenderer sr;
    float speed = 1f;
    bool playerClose = false;
    Rigidbody2D rb;
    Animator anim;
    HelperScript helper;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        helper = gameObject.AddComponent<HelperScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x > transform.position.x)
        {
            helper.FlipObject(true);    // this will execute the method in HelperScript.cs
            helper.walkLeft();
        }
        else
        {
            helper.FlipObject(false);
            helper.walkRight();
        }
    }

    /*
    void walkLeft()
    {
        transform.position = new Vector2(transform.position.x + (-speed * Time.deltaTime), transform.position.y);
    }
    void walkRight()
    {
        transform.position = new Vector2(transform.position.x + (speed * Time.deltaTime), transform.position.y);
    }
    */
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null && collision.gameObject.name == "player")
        {
            float collisionspeed = speed * -2;
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 2, ForceMode2D.Impulse);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.left * collisionspeed, ForceMode2D.Impulse);
            print("Collided with player");
        }
    }
}

