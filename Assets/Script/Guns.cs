using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Guns : MonoBehaviour
{

    public bool pis_equ = true;
    public bool shot_equ = false;
    public bool rock_equ = false;
    public bool cross_equ = false;
    int wpn_sel = 1;
    public float dame;
    public float range;

    public Rigidbody rb;

    public GameObject pistol;
    public GameObject shotgun;
    public GameObject rocket;
    public GameObject crossbow;

    public RawImage[] Crosshair;

    public int bullet_amount;

    public GameObject ply;
    public GameObject ene;

    public GameObject rkt_Proj;
    public GameObject dart_proj;

    public GameObject hit_ef;
    public GameObject hit_ef_e;
    public RaycastHit hit;

    public int bul_speed;

    public TrailRenderer trl;


    public ParticleSystem[] muzf;

    public Camera cam;

    void Start()
    {
        shotgun.SetActive(false);
        crossbow.SetActive(false);
        rocket.SetActive(false);
        for (int i = 0; i < 4; i++)
        {
            Crosshair[i].gameObject.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.forward * 40;
        if(Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            wpn_sel -= 1;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            wpn_sel += 1;

        }

        if (wpn_sel < 1)
        {
            wpn_sel = 4;
        }
        else if (wpn_sel > 4)
        {
            wpn_sel = 1;
        }
        weapon_selected(wpn_sel);

        bool fired = false;
        float timer = 0;
        
        if (pis_equ) {
            if (Input.GetButtonDown("Fire1") && timer <=0 && !fired)
            {
                muzf[0].Play();
                shot();
            }
        }
        if (shot_equ) {
            shotgun.transform.rotation = cam.transform.rotation;
            for (int i = 0; i < bullet_amount; i++) {
                if (Input.GetButtonDown("Fire1") && timer <= 0 && !fired)
                {
                    muzf[1].Play();
                    shot();
                }
            }
        }
        if (rock_equ) {
            rocket.transform.rotation = cam.transform.rotation;
            if (Input.GetButtonDown("Fire1") && timer <= 0 && !fired)
            {
                muzf[2].Play();
                shot();
            }
        }
        if (cross_equ)
        {
            crossbow.transform.rotation = cam.transform.rotation;
            if (Input.GetButtonDown("Fire1") && timer <= 0 && !fired)
            {
                
                shot();
            }
        }




        //Debug.Log(fired);
    }

    void shot()
    {
        if (pis_equ)
        {
            
            StartCoroutine(crosshair());
            
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
            {

                TrailRenderer spw_trl = Instantiate(trl, pistol.transform.position, pistol.transform.rotation);
                StartCoroutine(trail(spw_trl, hit.point));
                Smol_ene ene1 = hit.transform.GetComponent<Smol_ene>();

                if (ene1 != null)
                {
                    if (Vector3.Distance(ply.transform.position, ene.transform.position) < 15f)
                    {
                        if (ene1 != null)
                        {
                            Smol_ene.life -= dame;
                            GameObject inpc_e = Instantiate(hit_ef_e, hit.point, Quaternion.LookRotation(hit.normal));
                            Destroy(inpc_e, 2f);
                            Debug.Log(dame);
                        }
                    }
                    else if (Vector3.Distance(ply.transform.position, ene.transform.position) > 15f)
                    {

                        if (ene1 != null)
                        {
                            Smol_ene.life -= dame/2;
                            GameObject inpc_e = Instantiate(hit_ef_e, hit.point, Quaternion.LookRotation(hit.normal));
                            Destroy(inpc_e, 2f);
                            Debug.Log(dame / 2);
                        }
                    }
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
                TrailRenderer spw_trl = Instantiate(trl, pistol.transform.position, pistol.transform.rotation);
                StartCoroutine(trail(spw_trl, pistol.transform.position + pistol.transform.forward * 50));
            }
        }
        if (shot_equ)
        {
            Vector3 dir = cam.transform.forward;
            Vector3 spread = Vector3.zero;
            spread += cam.transform.up * Random.Range(-1f, 1f);
            spread += cam.transform.right * Random.Range(-1f, 1f);

            dir += spread.normalized * Random.Range(0f, 0.2f);
            if (Physics.Raycast(cam.transform.position, dir, out hit, range))
            {

                TrailRenderer spw_trl = Instantiate(trl, pistol.transform.position, pistol.transform.rotation);
                StartCoroutine(trail(spw_trl, hit.point));
                Smol_ene ene1 = hit.transform.GetComponent<Smol_ene>();
                if (ene1 != null)
                {
                    if (Vector3.Distance(ply.transform.position, ene.transform.position) < 15f)
                    {
                        if (ene1 != null)
                        {
                            Smol_ene.life -= dame;
                            GameObject inpc_e = Instantiate(hit_ef_e, hit.point, Quaternion.LookRotation(hit.normal));
                            Destroy(inpc_e, 2f);
                            Debug.Log(dame);
                        }
                    }
                    else if (Vector3.Distance(ply.transform.position, ene.transform.position) > 15f)
                    {

                        if (ene1 != null)
                        {
                            Smol_ene.life -= dame / 2;
                            GameObject inpc_e = Instantiate(hit_ef_e, hit.point, Quaternion.LookRotation(hit.normal));
                            Destroy(inpc_e, 2f);
                            Debug.Log(dame / 2);
                        }
                    }
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
                TrailRenderer spw_trl = Instantiate(trl, pistol.transform.position, pistol.transform.rotation);
                StartCoroutine(trail(spw_trl, pistol.transform.position + pistol.transform.forward * 50));
            }
        }
        if (cross_equ) {
            GameObject proj_c = Instantiate(dart_proj, cam.transform.position, cam.transform.rotation);
            proj_c.GetComponent<Rigidbody>().AddForce(cam.transform.forward * 40, ForceMode.Impulse);
            Destroy(proj_c, 2f);
        }
        if (rock_equ) {
            GameObject proj_R = Instantiate(rkt_Proj, cam.transform.position, cam.transform.rotation);
            proj_R.GetComponent<Rigidbody>().AddForce(cam.transform.forward * 40, ForceMode.Impulse);
            Destroy(proj_R, 2f);
        }
    }

    IEnumerator trail(TrailRenderer t, Vector3 dir)
    {
        Vector3 Startpos = t.transform.position;
        //var step = bul_speed * Time.deltaTime;
        float distance = Vector3.Distance(pistol.transform.position, hit.point);
        float Rdis = distance;
        while (Rdis > 0) {
            t.transform.position = Vector3.Lerp(Startpos, dir, 1 - (Rdis / distance));
            Rdis -= bul_speed * Time.deltaTime;
            yield return null;
        }
        Destroy(t.gameObject, trl.time);
    }

    IEnumerator crosshair()
    {
        Crosshair[0].transform.localScale = new Vector3(Crosshair[0].transform.localScale.x * 1.2f, Crosshair[0].transform.localScale.y * 1.2f, Crosshair[0].transform.localScale.z * 1.2f);
        yield return new WaitForSeconds(0.2f);
        Crosshair[0].transform.localScale = new Vector3(Crosshair[0].transform.localScale.x / 1.2f, Crosshair[0].transform.localScale.y / 1.2f, Crosshair[0].transform.localScale.z / 1.2f);
    }

    void weapon_selected(int sel)
    {

        if (sel == 1) {
            Crosshair[0].gameObject.SetActive(true);
            Crosshair[1].gameObject.SetActive(false);
            Crosshair[3].gameObject.SetActive(false);
            Crosshair[2].gameObject.SetActive(false);
            pistol.SetActive(true);
            shotgun.SetActive(false);
            crossbow.SetActive(false);
            rocket.SetActive(false);
            pis_equ = true;
            shot_equ = false;
            rock_equ = false;
            cross_equ = false;
        }
        else if (sel == 2)
        {
            Crosshair[0].gameObject.SetActive(false);
            Crosshair[1].gameObject.SetActive(true);
            Crosshair[3].gameObject.SetActive(false);
            Crosshair[2].gameObject.SetActive(false);
            pistol.SetActive(false);
            shotgun.SetActive(true);
            crossbow.SetActive(false);
            rocket.SetActive(false);
            pis_equ = false;
            shot_equ = true;
            rock_equ = false;
            cross_equ = false;
        }
        else if (sel == 3)
        {
            Crosshair[0].gameObject.SetActive(false);
            Crosshair[1].gameObject.SetActive(false);
            Crosshair[3].gameObject.SetActive(false);
            Crosshair[2].gameObject.SetActive(true);
            pistol.SetActive(false);
            shotgun.SetActive(false);
            crossbow.SetActive(false);
            rocket.SetActive(true);
            pis_equ = false;
            shot_equ = false;
            rock_equ = true;
            cross_equ = false;
        }
        else if (sel == 4)
        {
            Crosshair[0].gameObject.SetActive(false);
            Crosshair[1].gameObject.SetActive(false);
            Crosshair[3].gameObject.SetActive(true);
            Crosshair[2].gameObject.SetActive(false);
            pistol.SetActive(false);
            shotgun.SetActive(false);
            crossbow.SetActive(true);
            rocket.SetActive(false);
            pis_equ = false;
            shot_equ = false;
            rock_equ = false;
            cross_equ = true;
        }
    }
}
