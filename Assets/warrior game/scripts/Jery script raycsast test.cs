using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jeryscriptraycsasttest : MonoBehaviour
{
    HelperScript helper;
    float speed = -2f;
    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        helper = gameObject.AddComponent<HelperScript>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x + (speed * Time.deltaTime), transform.position.y);

        if (helper.GroundCheck(-0.3f,-0.2f) == false)
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
}
