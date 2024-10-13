using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Door_Animation : MonoBehaviour
{

    public InputAction open;
    public PlayerInput ply_in;

    private Animator animator;

    bool opened = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        open = ply_in.actions["Open"];
    }

    // Update is called once per frame
    void Update()
    {
        bool opin = open.WasPressedThisFrame();
        if (animator != null)
        {
            if (opin && Door.plyin && opened)
            {
                animator.SetTrigger("Close");
                opened = false;
            }
            else if (opin && Door.plyin && !opened) {
                animator.SetTrigger("Open");
                opened = true;
            }
        }
    }
}
