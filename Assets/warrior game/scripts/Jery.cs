using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Jery : MonoBehaviour
{
    HelperScript helper;
    bool onground = true;
    bool direction = true;
    // Start is called before the first frame update
    void Start()
    {
        helper = gameObject.AddComponent<HelperScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (helper.GroundCheckenemy(onground) == false)
        {
            helper.walkRight();
        }
        else if (helper.GroundCheckenemy(onground) == false)
        {
            helper.walkLeft();
        }
    }

}
