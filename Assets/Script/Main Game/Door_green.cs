using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_green : MonoBehaviour
{

    public static bool plyin = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (Player.grn_card)
        {
            plyin = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        plyin = false;
    }
}
