using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dart_proj : MonoBehaviour
{
    public ParticleSystem hit_ef;
    public ParticleSystem hit_ef_e;
    ParticleSystem inpc_e;
    ParticleSystem inpc;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            inpc_e = Instantiate(hit_ef_e, transform.position, transform.rotation);
            
        }
        else
        {
            inpc = Instantiate(hit_ef, transform.position, transform.rotation);
            
        }
        Destroy(inpc_e, 2f);
        Destroy(inpc, 2f);
        Destroy(gameObject);
    }
}
