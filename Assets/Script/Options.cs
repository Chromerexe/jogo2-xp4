using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour
{

    public static bool inv_camx = false;
    public static bool inv_camy = false;

    public void inv_cam_x()
    {
        inv_camx = true;
    }
    public void inv_cam_y()
    {
        inv_camy = true;
    }
}
