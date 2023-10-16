using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Jery : MonoBehaviour
{
    public float speed = 0.8f;
    public float range = 5f;
    public float Velocity = 5f;
    SpriteRenderer sr;
    Rigidbody2D rb;


    float startingX;
    int dir = 1;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        startingX = transform.position.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        sr.flipX = true;
        transform.Translate(Vector2.right * speed * Time.deltaTime * dir);
        if (transform.position.x < startingX || transform.position.x > startingX + range)
                dir *= -1;
                Velocity *= -1;
        if (dir == -1)
        {
            sr.flipX = false;
        }
       
    }
    private void OnCollisionEnter2D(Collision2D hitaway)
    {
        rb.AddForce(Vector2.up * Velocity, ForceMode2D.Impulse);
    }




}