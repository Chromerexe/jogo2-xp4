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

    public int bul_speed;

    public TrailRenderer trl;
    

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
                
                fired = true;
                
            }
        }
        


        //Debug.Log(timer);
        //Debug.Log(fired);
    }

    void shot()
    {
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {

            TrailRenderer spw_trl = Instantiate(trl, pis.transform.position, pis.transform.rotation);
            StartCoroutine(trail(spw_trl, hit.point));
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
        else
        {
            TrailRenderer spw_trl = Instantiate(trl, pis.transform.position, pis.transform.rotation);
            StartCoroutine(trail(spw_trl, pis.transform.position + pis.transform.forward * 50));
        }
    }

    IEnumerator trail(TrailRenderer t, Vector3 dir)
    {
        Vector3 Startpos = t.transform.position;
        //var step = bul_speed * Time.deltaTime;
        float distance = Vector3.Distance(pis.transform.position, hit.point);
        float Rdis = distance;
        while (Rdis > 0) {
            t.transform.position = Vector3.Lerp(Startpos, dir, 1 - (Rdis / distance));
            Rdis -= bul_speed * Time.deltaTime;
            yield return null;
        }
        Destroy(t.gameObject, trl.time);
    }
}
