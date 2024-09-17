using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smol_ene : MonoBehaviour
{

    public int life = 20;

    public void damege(int dam)
    {
        life -= dam;
        if(life <= 0)
        {
            Destroy(gameObject);
        }
    }
}
