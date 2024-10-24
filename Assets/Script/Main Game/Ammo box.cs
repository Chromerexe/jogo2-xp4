using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammobox : MonoBehaviour
{

    public bool pis_ammo;
    public bool shot_ammo;
    public bool rkt_ammo;
    public bool cross_ammo;

    public LayerMask ply;

    private void Update()
    {
        bool pick_up = Physics.CheckBox(transform.position, transform.forward, Quaternion.identity, ply);

        if (pick_up)
        {
            if (pis_ammo)
            {
                Guns.pis_amm += 10;
                Destroy(gameObject);
            }

            else if (shot_ammo)
            {
                Guns.shot_amm += 5;
                Destroy(gameObject);
            }

            else if (rkt_ammo)
            {
                Guns.rock_amm += 2;
                Destroy(gameObject);
            }

            else if (cross_ammo)
            {
                Guns.cross_amm += 4;
                Destroy(gameObject);
            }
        }
    }
}
