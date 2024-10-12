using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Animation_g : MonoBehaviour
{

    private Animator animator_g;

    bool opened_g = false;

    // Start is called before the first frame update
    void Start()
    {
        animator_g = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (animator_g != null && Player.grn_card)
        {
            if (Input.GetKeyDown(KeyCode.E) && Door_green.plyin && opened_g)
            {
                animator_g.SetTrigger("Close");
                opened_g = false;
            }
            else if (Input.GetKeyDown(KeyCode.E) && Door_green.plyin && !opened_g)
            {
                animator_g.SetTrigger("Open");
                opened_g = true;
            }
        }
    }
}
