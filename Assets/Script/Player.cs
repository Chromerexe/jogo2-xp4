using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class Player : MonoBehaviour
{

    public static float life = 10;
    public float vel = 0;
    public float Air_vel = 0;
    public float grav = 0;
    public float jump = 0;
    public static bool ply_ded = false;

    public Transform ply;

    public static bool grn_card = false;
    public static bool blu_card = false;

    public Transform grnd_c;
    public float grnd_d;
    public LayerMask grnd;

    public CharacterController control;

    public static Vector3 vel_g = Vector3.zero;
    bool isgrnd;
    bool ismovin = false;

    // Update is called once per frame
    void Update()
    {
        Debug.Log(ismovin);
        isgrnd = Physics.CheckSphere(grnd_c.position, grnd_d, grnd);

        if (isgrnd && vel_g.y < 0) {
            vel_g.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (x > 0 || z > 0)
        {
            ismovin = true;
        }

        Vector3 mov = transform.right * x + transform.forward * z;

        control.Move(mov * vel * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isgrnd)
        {
            vel_g.y = Mathf.Sqrt(jump * -2 * grav);
        }

        vel_g.y += grav * Time.deltaTime;

        
        control.Move(vel_g * Time.deltaTime);

        if (Rocket_proj.explosion_hit)
        {
            control.Move(transform.forward * 0.5f);
        }

        if (control.isGrounded) {
            Rocket_proj.explosion_hit = false;
        }
    }
}
