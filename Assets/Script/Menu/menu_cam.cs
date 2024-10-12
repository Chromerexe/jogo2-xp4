using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.UI;

public class menu_cam : MonoBehaviour
{

    public Animator cam;
    public Animator logo;
    public Animator start_txt;

    public Button[] butt;
    public Animator[] butt_ani;

    public TextMeshPro start;

    bool pressed = false;

    // Start is called before the first frame update
    void Start()
    {
        butt[0].gameObject.SetActive(false);
        butt[1].gameObject.SetActive(false);
        butt[2].gameObject.SetActive(false);
        logo.gameObject.SetActive(false);
        cam.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && !pressed)
        {
            pressed = true;
            start_txt.SetBool("return", false);
            start_txt.SetBool("pressed", true);
            StartCoroutine(log());
        }
        else if (Input.GetKey (KeyCode.Escape) && pressed) {
            pressed = false;
            start_txt.SetBool("pressed", false);
            butt_ani[0].SetBool("in", false);
            butt_ani[1].SetBool("in", false);
            butt_ani[2].SetBool("in", false);
            butt_ani[0].SetBool("out", true);
            butt_ani[1].SetBool("out", true);
            butt_ani[2].SetBool("out", true);
            logo.SetBool("Logo_return", true);
            logo.SetBool("Logo", false);
            StartCoroutine(log_r());
        }
    }

    IEnumerator log()
    {
        yield return new WaitForSeconds(1.2f);
        cam.SetBool("Return_menu 0", false);
        cam.SetBool("Menu Start 0", true);
        yield return new WaitForSeconds(2.5f);
        logo.gameObject.SetActive(true);
        logo.SetBool("Logo_return", false);
        logo.SetBool("Logo", true);
        butt[0].gameObject.SetActive(true);
        butt[1].gameObject.SetActive(true);
        butt[2].gameObject.SetActive(true);
        butt_ani[0].SetBool("out", false);
        butt_ani[1].SetBool("out", false);
        butt_ani[2].SetBool("out", false);
        butt_ani[0].SetBool("in", true);
        butt_ani[1].SetBool("in", true);
        butt_ani[2].SetBool("in", true);
    }
    IEnumerator log_r()
    {
        yield return new WaitForSeconds(1.5f);
        logo.gameObject.SetActive(false);
        cam.SetBool("Return_menu 0", true);
        cam.SetBool("Menu Start 0", false);
        butt[0].gameObject.SetActive(false);
        butt[1].gameObject.SetActive(false);
        butt[2].gameObject.SetActive(false);
        yield return new WaitForSeconds(2.5f);
        start_txt.SetBool("return", true);
    }
}
