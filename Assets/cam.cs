using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class cam : MonoBehaviour
{
    public float rotx = 0f;
    public float roty = 0f;

    public Transform ply;

    public float sens = 150f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        rotx -= Input.GetAxis("Mouse Y") * Time.deltaTime * sens;
        roty += Input.GetAxis("Mouse X") * Time.deltaTime * sens;

        rotx = Mathf.Clamp(rotx, -90f, 90f);

        transform.rotation = Quaternion.Euler(rotx, roty, 0f);
        ply.rotation = Quaternion.Euler(0f, roty, 0f);
    }
}
