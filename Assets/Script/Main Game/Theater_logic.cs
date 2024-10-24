using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Theater_logic : MonoBehaviour
{

    public MeshCollider ruble;
    public MeshCollider ruble2;

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(ruble_fall());
    }

    IEnumerator ruble_fall()
    {
        yield return new WaitForSeconds(1);
        ruble.enabled = true;
        ruble2.enabled = true;
    }
}
