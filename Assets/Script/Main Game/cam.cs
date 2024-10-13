using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class cam : MonoBehaviour
{
    //Cam_mov

    public PlayerInput ply_in;
    public InputAction cam_move;

    public float rotx = 0f;
    public float roty = 0f;

    float xrot;

    public Transform ply;

    public float sens = 150f;

    void Start()
    {
        cam_move = ply_in.actions["Cam_mov"];
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 cam_lol = cam_move.ReadValue<Vector2>();

        if (!Options.inv_camx)
        {
            rotx = cam_lol.x * Time.deltaTime * sens;
        }

        else
        {
            rotx = -cam_lol.x * Time.deltaTime * sens;
        }

        if (!Options.inv_camy)
        {
            roty = cam_lol.y * Time.deltaTime * sens;
        }

        else
        {
            roty = -cam_lol.y * Time.deltaTime * sens;
        }

        xrot -= roty;
        xrot = Mathf.Clamp(xrot, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xrot,0f,0f);
        ply.Rotate(Vector3.up * rotx);
    }
}
