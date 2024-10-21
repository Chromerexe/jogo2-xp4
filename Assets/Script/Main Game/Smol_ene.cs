using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class Smol_ene : MonoBehaviour
{
    public float life = 20;
    public float sight_dis = 20f;
    public float fov = 85f;
    public GameObject ply;
    public NavMeshAgent agent;


    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        canseeplayer();
        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }

    public bool canseeplayer()
    {
        if (ply != null)
        {
            if (Vector3.Distance(transform.position, ply.transform.position) < sight_dis) 
            {
                Vector3 trg_dir = ply.transform.position - transform.position;
                float ang_ply = Vector3.Angle(trg_dir, transform.forward);
                if(ang_ply >= -fov && ang_ply <= fov) {
                    Ray ray = new Ray(transform.position, trg_dir);
                    RaycastHit hit = new RaycastHit();
                    if(Physics.Raycast(ray, out hit, sight_dis)) 
                    {
                        return true;
                    }
                    Debug.DrawRay(ray.origin, ray.direction * sight_dis);
                }
            }
        }
        return false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Rocket")
        {
            life -= 10;
        }
        else if (collision.collider.tag == "Cross")
        {
            life -= 5;
        }
    }
}
