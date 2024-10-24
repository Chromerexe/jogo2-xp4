using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle1_logic : MonoBehaviour
{

    public static int ene_def = 0;

    public Animator anim;

    public Animator anim2;

    // Update is called once per frame
    void Update()
    {
        if(ene_def >= 5) {
            anim.SetTrigger("open");
            anim2.SetTrigger("open");
        }
    }
}
