using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Door_Animation_g : MonoBehaviour
{
    public InputAction open;
    public PlayerInput ply_in;

    private Animator animator_g;

    bool opened_g = false;

    // Start is called before the first frame update
    void Start()
    {
        animator_g = GetComponent<Animator>();
        open = ply_in.actions["Open"];
    }

    // Update is called once per frame
    void Update()
    {
        bool opin = open.WasPressedThisFrame();

        if (animator_g != null && Player.grn_card)
        {
            if (opin && Door_green.plyin && opened_g)
            {
                animator_g.SetTrigger("Close");
                opened_g = false;
            }
            else if (opin && Door_green.plyin && !opened_g)
            {
                animator_g.SetTrigger("Open");
                opened_g = true;
            }
        }
    }
}
