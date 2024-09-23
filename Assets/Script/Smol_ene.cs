using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smol_ene : MonoBehaviour
{

    public float life = 20;

    public void damege(float dam)
    {
        life -= dam;
        if(life <= 0)
        {
            Destroy(gameObject);
        }
    }
}
