using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_blue : MonoBehaviour
{

    public static bool plyin = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(Player.blu_card)
        {
            plyin = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        plyin = false;
    }
}
