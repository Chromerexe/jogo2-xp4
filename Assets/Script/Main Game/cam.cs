using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class cam : MonoBehaviour
{
    public float rotx = 0f;
    public float roty = 0f;

    float xrot;

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
        rotx = Input.GetAxis("Mouse X") * Time.deltaTime * sens;
        roty = Input.GetAxis("Mouse Y") * Time.deltaTime * sens;

        xrot -= roty;
        xrot = Mathf.Clamp(xrot, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xrot,0f,0f);
        ply.Rotate(Vector3.up * rotx);
    }
}
