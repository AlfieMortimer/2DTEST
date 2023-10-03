using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{

    Rigidbody2D rb;
    float jumpAmount = 5f;
    Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        anim.SetBool("jump", false);

        Color hitColor = Color.white;
        bool onground = false;
        float laserLength = 0.4f;
        Vector3 rayOffset = new Vector3(0, -1.0f,0 );

        RaycastHit2D hit = Physics2D.Raycast(transform.position + rayOffset, Vector2.down, laserLength);


        if (hit.collider != null)
        {
            hitColor = Color.red;    
        }
        Debug.DrawRay(transform.position + rayOffset, Vector2.down * laserLength,  hitColor );


        if (hit.collider != null)
        {
            print(hit.collider.tag);
            onground = true;

        }

        if (Input.GetKeyDown(KeyCode.Space) && onground == true)
        {
            rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
            anim.SetBool("jump", true);
        }
    }
}
