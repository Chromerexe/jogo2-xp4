using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ui : MonoBehaviour
{

    public Slider life_ui;

    // Update is called once per frame
    void Update()
    {
        life_ui.value = Player.life;
    }
}
