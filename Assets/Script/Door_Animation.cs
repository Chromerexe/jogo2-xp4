using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Animation : MonoBehaviour
{

    private Animator animator;

    bool opened = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (animator != null)
        {
            if (Input.GetKeyDown(KeyCode.E) && Door.plyin && opened)
            {
                animator.SetTrigger("Close");
                opened = false;
            }
            else if (Input.GetKeyDown(KeyCode.E) && Door.plyin && !opened) {
                animator.SetTrigger("Open");
                opened = true;
            }
        }
    }
}
