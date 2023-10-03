using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    SpriteRenderer sr;
    float speed = 2f;
    bool playerClose = false;
    Rigidbody2D rb;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 scale = transform.localScale;

        if (player.transform.position.x > transform.position.x)
        {
            sr.flipX = true;
            walkRight();
        }
        else if (player.transform.position.x < transform.position.x)
        {
            sr.flipX = false;
            walkLeft();
        }

        transform.localScale = scale;
    }
    void walkLeft()
    {
        transform.position = new Vector2(transform.position.x + (-speed * Time.deltaTime), transform.position.y);
    }
    void walkRight()
    {
        transform.position = new Vector2(transform.position.x + (speed * Time.deltaTime), transform.position.y);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null && collision.gameObject.name == "player")
        {
            anim.SetBool("dead", true);
            Object.Destroy(GetComponent<Rigidbody>());
            Destroy(this.gameObject);

        }
        
    }
}

