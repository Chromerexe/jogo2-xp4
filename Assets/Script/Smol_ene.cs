using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smol_ene : MonoBehaviour
{
    public static float life = 20;

    private void Update()
    {
        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }
}
