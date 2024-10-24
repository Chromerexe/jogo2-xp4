using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ui : MonoBehaviour
{
    public RawImage[] guns;
    public Guns gun;
    public TMP_Text ammo;
    public Slider life_ui;

    private void Start()
    {
        guns[0].enabled = false;
        guns[1].enabled = false;
        guns[2].enabled = false;
        guns[3].enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (gun.pis_equ)
        {
            guns[0].enabled = true;
            guns[1].enabled = false;
            guns[2].enabled = false;
            guns[3].enabled = false;
            ammo.text = gun.pis_amm2.ToString();
        }
        if (gun.shot_equ)
        {
            guns[0].enabled = false;
            guns[1].enabled = true;
            guns[2].enabled = false;
            guns[3].enabled = false;
            ammo.text = gun.shot_amm2.ToString();
        }
        if (gun.rock_equ)
        {
            guns[0].enabled = false;
            guns[1].enabled = false;
            guns[2].enabled = true;
            guns[3].enabled = false;
            ammo.text = gun.rock_amm2.ToString();
        }
        if (gun.cross_equ)
        {
            guns[0].enabled = false;
            guns[1].enabled = false;
            guns[2].enabled = false;
            guns[3].enabled = true;
            ammo.text = gun.cross_amm2.ToString();
        }
        life_ui.value = Player.life;
    }
}
