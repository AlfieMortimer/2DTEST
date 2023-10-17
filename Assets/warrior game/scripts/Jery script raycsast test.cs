using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jeryscriptraycsasttest : MonoBehaviour
{
    HelperScript helper;
    float speed = -2f;
    SpriteRenderer sr;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        helper = gameObject.AddComponent<HelperScript>();
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x + (speed * Time.deltaTime), transform.position.y);

        if (helper.GroundCheck(-0.3f, -0.2f) == false)
        {
            speed *= -1;
            sr.flipX = true;
        }
        if (helper.GroundCheck(0.3f, -0.2f) == false)
        {
            speed *= -1;
            sr.flipX = false;

        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null && collision.gameObject.name == "player")
        {
            float collisionspeed = speed * -3;
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 2, ForceMode2D.Impulse);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.left * collisionspeed, ForceMode2D.Impulse);
            print("Collided with player");
        }
    }
}
