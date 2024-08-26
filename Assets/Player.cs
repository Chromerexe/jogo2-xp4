using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class Player : MonoBehaviour
{

    public static float life = 0;
    public float vel = 0;
    public float turn = 0;
    public static bool ply_ded = false;
    public float ply_h;

    public LayerMask grnd;
    public Rigidbody ply;
    private Vector3 mov;
    public Transform cam;

    bool ong;

    // Start is called before the first frame update
    void Start()
    {
        ply.constraints = RigidbodyConstraints.FreezeRotationX;
        ply.constraints = RigidbodyConstraints.FreezeRotationZ;
        ply.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ong = Physics.Raycast(ply.position, Vector3.down, ply_h * 0.5f + 0.2f, grnd);

        if (ong)
        {
            ply.drag = 10f;
        }

        else
        {
            ply.drag = 0f;
        }
    }

    void FixedUpdate()
    {
        if (!ply_ded) {
            float horizontalinput = Input.GetAxis("Horizontal");
            float verticalinput = Input.GetAxis("Vertical");

            mov = cam.forward * verticalinput + cam.right * horizontalinput;

            ply.MovePosition(ply.position + mov.normalized * vel * Time.deltaTime);
        }
    }
}
