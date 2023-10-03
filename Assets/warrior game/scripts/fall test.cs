using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class falltest : MonoBehaviour
{
    // Start is called before the first frame update

    Animator anim;  // ***
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>(); // ***
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
