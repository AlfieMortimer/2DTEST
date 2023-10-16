using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jeryscriptraycsasttest : MonoBehaviour
{
    HelperScript helper;

    // Start is called before the first frame update
    void Start()
    {
        helper = gameObject.AddComponent<HelperScript>();
    }

    // Update is called once per frame
    void Update()
    {
        helper.GroundCheck(-0.3f,0 );
        helper.GroundCheck(0.3f, 0);
    }
}
