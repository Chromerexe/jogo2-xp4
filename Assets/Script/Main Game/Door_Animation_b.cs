using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Door_Animation_b : MonoBehaviour
{
    public InputAction open;
    public PlayerInput ply_in;

    private Animator animator_b;

    bool opened_b = false;

    // Start is called before the first frame update
    void Start()
    {
        animator_b = GetComponent<Animator>();
        open = ply_in.actions["Open"];
    }

    // Update is called once per frame
    void Update()
    {
        bool opin = open.WasPressedThisFrame();
        if (animator_b != null && Player.blu_card)
        {
            if (opin && Door_blue.plyin && opened_b)
            {
                animator_b.SetTrigger("Close");
                opened_b = false;
            }
            else if (opin && Door_blue.plyin && !opened_b)
            {
                animator_b.SetTrigger("Open");
                opened_b = true;
            }
        }
    }
}
