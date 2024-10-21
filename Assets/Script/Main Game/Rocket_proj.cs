using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using static UnityEditor.Progress;

public class Rocket_proj : MonoBehaviour
{

    public ParticleSystem explo;
    public LayerMask ply;
    public LayerMask ene;
    public int explode_r;
    public Transform bleh;

    public static bool explosion_hit;

    private void OnCollisionEnter(Collision collision)
    {
        explosion_hit = Physics.CheckSphere(gameObject.transform.position, explode_r, ply);
        if (explosion_hit)
        {
            Player.vel_g = new Vector3(0, 50.0f, 0);
        }

        ParticleSystem exp = Instantiate(explo, transform.position, transform.rotation);

        StartCoroutine(deleteall(exp));
        Destroy(gameObject);
    }

    IEnumerator deleteall(ParticleSystem ex)
    {
        yield return new WaitForSeconds(2);
        Destroy(ex);
    }
}