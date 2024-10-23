using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Trigger : MonoBehaviour
{
    public Smol_ene[] ene;
    private void OnTriggerEnter(Collider other)
    {
        foreach (Smol_ene en in ene)
        {
            en.transform.LookAt(en.presentation.transform.position);
            en.agent.SetDestination(en.presentation.transform.position);
            en.GetComponent<NavMeshAgent>().speed = 15f;
        }   
        
    }
}
