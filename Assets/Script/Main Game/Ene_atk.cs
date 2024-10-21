using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ene_atk : MonoBehaviour
{
    public Smol_ene ene;
    public Player ply;
    public float mov_timer;
    public bool saw = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ene.canseeplayer())
        {
            saw = true;
        }

        if (saw){
            ene.agent.SetDestination(ply.transform.position);
            if (Vector3.Distance(ply.transform.position, ene.transform.position) < 20f)
            {
                ene.agent.isStopped = true;
            }
            else
            {
                ene.agent.isStopped = false;
            }
        }
    }
}
