using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Options_menu : MonoBehaviour
{
    bool gmpl_opt = true;
    bool displ_opt = false;
    bool grph_opt = false;
    bool sfx_opt = false;
    bool lng_opt = false;

    public GameObject gmpl;
    public GameObject displ;
    public GameObject grph;
    public GameObject sfx;
    public GameObject lng;

    public Button[] options;

    public GameObject opt_menu;

    public Button gameplay_btn;

    public bool opt_menu_open = false;

    public GameObject pnl;

    // Start is called before the first frame update
    void Start()
    {
        gmpl.SetActive(false);
        displ.SetActive(false);
        grph.SetActive(false);
        sfx.SetActive(false);
        lng.SetActive(false);
        opt_menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (gmpl_opt)
        {
            gmpl.SetActive(true);
            displ.SetActive(false);
            grph.SetActive(false);
            sfx.SetActive(false);
            lng.SetActive(false);

        }
        if (displ_opt)
        {
            gmpl.SetActive(false);
            displ.SetActive(true);
            grph.SetActive(false);
            sfx.SetActive(false);
            lng.SetActive(false);
        }
        if (grph_opt)
        {
            gmpl.SetActive(false);
            displ.SetActive(false);
            grph.SetActive(true);
            sfx.SetActive(false);
            lng.SetActive(false);
        }
        if (sfx_opt)
        {
            gmpl.SetActive(false);
            displ.SetActive(false);
            grph.SetActive(false);
            sfx.SetActive(true);
            lng.SetActive(false);
        }
        if (lng_opt)
        {
            gmpl.SetActive(false);
            displ.SetActive(false);
            grph.SetActive(false);
            sfx.SetActive(false);
            lng.SetActive(true);
        }
    }

    public void returning()
    {
        gmpl.SetActive(false);
        displ.SetActive(false);
        grph.SetActive(false);
        sfx.SetActive(false);
        lng.SetActive(false);
        gmpl_opt = true;
        displ_opt = false;
        grph_opt = false;
        sfx_opt = false;
        lng_opt = false;
        StartCoroutine(waitthigie());
    }

    IEnumerator waitthigie()
    {
        yield return new WaitForSeconds(0.2f);
        opt_menu_open = false;
        opt_menu.SetActive(false);
    }

    public void opt_button()
    {
        opt_menu_open =true;
        opt_menu.SetActive(true);
        gameplay_btn.Select();
        options[0].interactable = false;
        options[1].interactable = true;
        options[2].interactable = true;
        options[3].interactable = true;
        options[4].interactable = true;
    }

    public void gmp()
    {
        options[0].interactable = false;
        options[1].interactable = true;
        options[2].interactable = true;
        options[3].interactable = true;
        options[4].interactable = true;
        
        gmpl_opt = true;
        displ_opt = false;
        grph_opt = false;
        sfx_opt = false;
        lng_opt = false;
    }
    public void dis()
    {
        options[0].interactable = true;
        options[1].interactable = false;
        options[2].interactable = true;
        options[3].interactable = true;
        options[4].interactable = true;
        
        gmpl_opt = false;
        displ_opt = true;
        grph_opt = false;
        sfx_opt = false;
        lng_opt = false;
    }
    public void gra()
    {
        options[0].interactable = true;
        options[1].interactable = true;
        options[2].interactable = false;
        options[3].interactable = true;
        options[4].interactable = true;
        
        gmpl_opt = false;
        displ_opt = false;
        grph_opt = true;
        sfx_opt = false;
        lng_opt = false;
    }
    public void sfu()
    {
        options[0].interactable = true;
        options[1].interactable = true;
        options[2].interactable = true;
        options[3].interactable = false;
        options[4].interactable = true;
        
        gmpl_opt = false;
        displ_opt = false;
        grph_opt = false;
        sfx_opt = true;
        lng_opt = false;
    }
    public void lang()
    {
        options[0].interactable = true;
        options[1].interactable = true;
        options[2].interactable = true;
        options[3].interactable = true;
        options[4].interactable = false;
        gmpl_opt = false;
        displ_opt = false;
        grph_opt = false;
        sfx_opt = false;
        lng_opt = true;
    }
}
