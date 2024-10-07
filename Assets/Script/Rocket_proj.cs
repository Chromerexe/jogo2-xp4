using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket_proj : MonoBehaviour
{

    public ParticleSystem explo;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            Smol_ene.life -= 10f;
            
        }

        ParticleSystem exp = Instantiate(explo, transform.position, transform.rotation);

        Destroy(exp,2f);
        Destroy(gameObject);
    }
}
