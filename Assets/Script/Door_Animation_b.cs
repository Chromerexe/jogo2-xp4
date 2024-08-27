using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Animation_b : MonoBehaviour
{

    private Animator animator_b;

    bool opened_b = false;

    // Start is called before the first frame update
    void Start()
    {
        animator_b = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (animator_b != null && Player.blu_card)
        {
            if (Input.GetKeyDown(KeyCode.E) && Door_blue.plyin && opened_b)
            {
                animator_b.SetTrigger("Close");
                opened_b = false;
            }
            else if (Input.GetKeyDown(KeyCode.E) && Door_blue.plyin && !opened_b)
            {
                animator_b.SetTrigger("Open");
                opened_b = true;
            }
        }
    }
}
