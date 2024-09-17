using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{

    public static bool pis_equ = true;
    public int dame;
    public float range;
    public Transform pis;

    public GameObject hit_ef;
    public GameObject hit_ef_e;
    public RaycastHit hit;

    public TrailRenderer trl;
    TrailRenderer spw_trl;

    public ParticleSystem muzf;

    public Camera cam;

    // Update is called once per frame
    void Update()
    {
        bool fired = false;
        float timer = 0;
        
        if (pis_equ) {
            pis.rotation = cam.transform.rotation;
            if (Input.GetButtonDown("Fire1") && timer <=0 && !fired)
            {
                muzf.Play();
                shot();
            }
        }
        

        //Debug.Log(timer);
        //Debug.Log(fired);
    }

    void shot()
    {
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            spw_trl = Instantiate(trl, pis.transform.position, pis.transform.rotation);
            StartCoroutine(trail(spw_trl));
            
            Smol_ene ene1 = hit.transform.GetComponent<Smol_ene>();

            if (ene1 != null) {
                ene1.damege(dame);
                GameObject inpc_e = Instantiate(hit_ef_e, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(inpc_e, 2f);
            }
            
            else
            {
                GameObject inpc = Instantiate(hit_ef, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(inpc, 2f);
            }
            Debug.Log("ya hit it m8");
        }
    }

    IEnumerator trail(TrailRenderer t)
    {
        float distance = Vector3.Distance(t.transform.position, hit.point);
        float Rdis = distance;
        if (Rdis > 0)
        {
            t.transform.position = Vector3.MoveTowards(pis.position, hit.point, 10);
            Rdis -= 1 *Time.deltaTime;
            yield return null;
        }
    }
}
