using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{

    public Animator panel;


    private void Start()
    {
        panel.gameObject.SetActive(false);
    }
    public void yee()
    {
        panel.gameObject.SetActive(true);
        StartCoroutine(loadnxt());
    }

    IEnumerator loadnxt()
    {
        panel.SetBool("fade", true);
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene("Main");
    }
}
