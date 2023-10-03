using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Tilemaps;
using UnityEngine;



public class PlayerScript : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    bool onground = true;
    Animator anim;
    SpriteRenderer sr;
    float jumpAmount = 5f;

    void Start()
    {
        print("Player Start");
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        float speed = 1.5f;

        anim.SetBool("walk", false);


        if ((Input.GetKey("left") || Input.GetKey("a")) == true)
        {
            print("Player left");
            anim.SetBool("walk", true);
            sr.flipX = true;
            transform.position = new Vector2(transform.position.x + (-speed * Time.deltaTime), transform.position.y);
        }
        else if ((Input.GetKey("right") || Input.GetKey("d")) == true)
        {
            print("Player right");
            anim.SetBool("walk", true);
            transform.position = new Vector2(transform.position.x + (speed * Time.deltaTime), transform.position.y);
            sr.flipX = false;
        }

        //shift + direction

        if (((Input.GetKey("left") && (Input.GetKey(KeyCode.LeftShift)) || (Input.GetKey("a")) && (Input.GetKey(KeyCode.LeftShift) == true))))
        {
            speed = 2f;
            print("Player left");
            anim.SetBool("walk", true);
            transform.position = new Vector2(transform.position.x + (-speed * Time.deltaTime), transform.position.y);
        }
        else if (((Input.GetKey("right") && (Input.GetKey(KeyCode.LeftShift)) || (Input.GetKey("d")) && (Input.GetKey(KeyCode.LeftShift) == true))))
        {
            speed = 2f;
            print("Player sprint right");
            anim.SetBool("walk", true);
            transform.position = new Vector2(transform.position.x + (+speed * Time.deltaTime), transform.position.y);
        }

        //jump

        Color hitColor = Color.white;
        bool onground = false;
        float laserLength = 0.2f;
        Vector3 rayOffset = new Vector3(0, -1.0f, 0);

        RaycastHit2D hit = Physics2D.Raycast(transform.position + rayOffset, Vector2.down, laserLength);


        if (hit.collider != null)
        {
            hitColor = Color.red;
        }
        Debug.DrawRay(transform.position + rayOffset, Vector2.down * laserLength, hitColor);


        if (hit.collider != null)
        {
            
            onground = true;
            anim.SetBool("jump", false);

        }

        if (onground == false)
        {
            anim.SetBool("jump", true);
        }


        if (Input.GetKeyDown(KeyCode.Space) && onground == true)
        {
            rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
        }

        //attack

        if(Input.GetKeyDown("r") == true)
        {
            anim.SetTrigger("attack");
        }
    }
}
    



    