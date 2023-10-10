using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;


public class HelperScript : MonoBehaviour
{
    LayerMask groundLayerMask;
    public GameObject player;

    public void FlipObject(bool flip)
    {
        // get the SpriteRenderer component
        SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();

        if (flip == true)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
    }


    public void walkLeft()
    {
        transform.position = new Vector2(transform.position.x + (2f * Time.deltaTime), transform.position.y);
    }
    public void walkRight()
    {
        transform.position = new Vector2(transform.position.x + (-2f * Time.deltaTime), transform.position.y);
    }

    public bool GroundCheck(bool onGround)
    {
        groundLayerMask = LayerMask.GetMask("Ground");

        Color hitColor = Color.white;
        bool onground = false;
        float laserLength = 0.1f;
        Vector3 rayOffset = new Vector3(0, -0.35f, 0);
        Vector3 rayOffset2 = new Vector3(-0.1f, -0.35f, 0);
        Vector3 rayOffset3 = new Vector3(0.1f, -0.35f, 0);

        RaycastHit2D hit = Physics2D.Raycast(transform.position + rayOffset, Vector2.down, laserLength, groundLayerMask);
        RaycastHit2D hit2 = Physics2D.Raycast(transform.position + rayOffset2, Vector2.down, laserLength, groundLayerMask);
        RaycastHit2D hit3 = Physics2D.Raycast(transform.position + rayOffset3, Vector2.down, laserLength, groundLayerMask);

        if ((hit.collider != null) || (hit2.collider != null) || (hit3.collider != null))
        {
            hitColor = Color.red;
        }
        Debug.DrawRay(transform.position + rayOffset, Vector2.down * laserLength, hitColor);
        Debug.DrawRay(transform.position + rayOffset2, Vector2.down * laserLength, hitColor);
        Debug.DrawRay(transform.position + rayOffset3, Vector2.down * laserLength, hitColor);

        if ((hit.collider != null) || (hit2.collider != null) || (hit3.collider != null))
        {

            onground = true;
        }
        else
        {
            onground = false;
        }
        return onground;
    }
    public bool GroundCheckenemy(bool onGround)
    {
        Color hitColor1 = Color.white;
        Color hitColor2 = Color.white;
        float laserLength = 0.1f;
        bool onground = false;


        Vector3 rayOffset2 = new Vector3(-0.1f, -0.35f, 0);
        Vector3 rayOffset3 = new Vector3(0.1f, -0.35f, 0);

        RaycastHit2D hit2 = Physics2D.Raycast(transform.position + rayOffset2, Vector2.down, laserLength);
        RaycastHit2D hit3 = Physics2D.Raycast(transform.position + rayOffset3, Vector2.down, laserLength);

        if (hit2.collider != null)
        {
            hitColor1 = Color.red;
        }
        if (hit3.collider != null)
        {
            hitColor2 = Color.red;
        }
        Debug.DrawRay(transform.position + rayOffset2, Vector2.down * laserLength, hitColor1);
        Debug.DrawRay(transform.position + rayOffset3, Vector2.down * laserLength, hitColor2);

        if (hit2.collider == null)
        {
            onground = true;
        }
        else if (hit3.collider == null)
        {
            onground = false;
        }
        return onground;

    }


}
