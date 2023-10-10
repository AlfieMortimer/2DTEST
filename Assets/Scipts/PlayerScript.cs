using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Tilemaps;
using UnityEngine;

//dont look here! it is ugly! :3

public class PlayerScript : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    bool onground = true;
    Animator anim;
    SpriteRenderer sr;
    float jumpAmount = 4.5f;
    HelperScript helper;
    LayerMask groundLayerMask;

    void Start()
    {
        print("Player Start");
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        helper = gameObject.AddComponent<HelperScript>();
        groundLayerMask = LayerMask.GetMask("Ground");
    }

    // Update is called once per frame
    void Update()
    {

        float speed = 1.5f;

        anim.SetBool("walk", false);
        anim.speed = 1f;
      
        //left 

        if ((Input.GetKey("left") || Input.GetKey("a")) == true)
        {
            anim.SetBool("walk", true);
            sr.flipX = true;
            transform.position = new Vector2(transform.position.x + (-speed * Time.deltaTime), transform.position.y);
        }

        //right

        else if ((Input.GetKey("right") || Input.GetKey("d")) == true)
        {

            anim.SetBool("walk", true);
            transform.position = new Vector2(transform.position.x + (speed * Time.deltaTime), transform.position.y);
            sr.flipX = false;
        }

        //shift + direction

        if (((Input.GetKey("left") && (Input.GetKey(KeyCode.LeftShift)) || (Input.GetKey("a")) && (Input.GetKey(KeyCode.LeftShift) == true))))
        {
            speed = 2.5f;
            anim.SetBool("walk", true);
            anim.speed = 2;
            transform.position = new Vector2(transform.position.x + (-speed * Time.deltaTime), transform.position.y);
        }
        else if (((Input.GetKey("right") && (Input.GetKey(KeyCode.LeftShift)) || (Input.GetKey("d")) && (Input.GetKey(KeyCode.LeftShift) == true))))
        {
            speed = 2.5f;
            anim.SetBool("walk", true);
            anim.speed = 2;
            transform.position = new Vector2(transform.position.x + (+speed * Time.deltaTime), transform.position.y);
        }

        //jump



        if (helper.GroundCheck(onground) == true)
        {
            anim.SetBool("jump", false);
        }

        if (helper.GroundCheck(onground) == false)
        {
            anim.SetBool("jump", true);
        }


        if (Input.GetKeyDown(KeyCode.Space) && helper.GroundCheck(onground) == true)
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
    



    