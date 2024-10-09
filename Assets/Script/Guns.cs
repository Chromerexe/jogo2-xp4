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
    int last_wpn = 1;
    int last_wpn2;
    bool wpn_curt_switch = false;
    public float dame;
    public float range;

    public Rigidbody rb;

    public GameObject gun_p;
    public GameObject gun_p2;
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
        gun_p.transform.rotation = new Quaternion(-cam.transform.rotation.x, -cam.transform.rotation.y, -cam.transform.rotation.z, -cam.transform.rotation.w);
        gun_p2.transform.rotation = new Quaternion(-cam.transform.rotation.x, -cam.transform.rotation.y, -cam.transform.rotation.z, -cam.transform.rotation.w);
        rb.velocity = transform.forward * 40;
        if(Input.GetAxis("Mouse ScrollWheel") > 0f && !wpn_curt_switch)
        {
            wpn_curt_switch = true;
            last_wpn = wpn_sel;
            wpn_sel -= 1;
            wpn_curt_switch = false;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f && !wpn_curt_switch)
        {
            wpn_curt_switch = true;
            last_wpn = wpn_sel;
            wpn_sel += 1;
            wpn_curt_switch = false;
        }

        if (wpn_sel < 1 && !wpn_curt_switch)
        {
            wpn_curt_switch = true;
            wpn_sel = 4;
            wpn_curt_switch = false;
        }
        else if (wpn_sel > 4 && !wpn_curt_switch)
        {
            wpn_curt_switch = true;
            wpn_sel = 1;
            wpn_curt_switch = false;
        }

        if(Input.GetKeyDown(KeyCode.Q) && !wpn_curt_switch)
        {
            wpn_curt_switch = true;
            last_wpn2 = wpn_sel;
            wpn_sel = last_wpn;
            last_wpn = last_wpn2;
            wpn_curt_switch = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1) && !wpn_curt_switch)
        {
            wpn_curt_switch = true;
            last_wpn = wpn_sel;
            wpn_sel = 1;
            wpn_curt_switch = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && !wpn_curt_switch)
        {
            wpn_curt_switch = true;
            last_wpn = wpn_sel;
            wpn_sel = 2;
            wpn_curt_switch = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && !wpn_curt_switch)
        {
            wpn_curt_switch = true;
            last_wpn = wpn_sel;
            wpn_sel = 3;
            wpn_curt_switch = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && !wpn_curt_switch)
        {
            wpn_curt_switch = true;
            last_wpn = wpn_sel;
            wpn_sel = 4;
            wpn_curt_switch = false;
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
            for (int i = 0; i < bullet_amount; i++) {
                if (Input.GetButtonDown("Fire1") && timer <= 0 && !fired)
                {
                    muzf[1].Play();
                    shot();
                }
            }
        }
        if (rock_equ) {
            if (Input.GetButtonDown("Fire1") && timer <= 0 && !fired)
            {
                muzf[2].Play();
                shot();
            }
        }
        if (cross_equ)
        {
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
            
            if (Physics.Raycast(gun_p.transform.position, gun_p.transform.forward, out hit, range))
            {

                TrailRenderer spw_trl = Instantiate(trl, gun_p.transform.position, cam.transform.rotation);
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
                TrailRenderer spw_trl = Instantiate(trl, gun_p.transform.position, cam.transform.rotation);
                StartCoroutine(trail(spw_trl, gun_p.transform.position + gun_p.transform.forward * 50));
            }
        }
        if (shot_equ)
        {
            Vector3 dir = gun_p.transform.forward;
            Vector3 spread = Vector3.zero;
            spread += gun_p.transform.up * Random.Range(-1f, 1f);
            spread += gun_p.transform.right * Random.Range(-1f, 1f);

            dir += spread.normalized * Random.Range(0f, 0.2f);
            if (Physics.Raycast(gun_p.transform.position, dir, out hit, range))
            {

                TrailRenderer spw_trl = Instantiate(trl, gun_p.transform.position, cam.transform.rotation);
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
                TrailRenderer spw_trl = Instantiate(trl, gun_p.transform.position, cam.transform.rotation);
                StartCoroutine(trail(spw_trl, gun_p.transform.position + gun_p.transform.forward * 50));
            }
        }
        if (cross_equ) {
            GameObject proj_c = Instantiate(dart_proj, gun_p.transform.position, cam.transform.rotation);
            proj_c.GetComponent<Rigidbody>().AddForce(gun_p.transform.forward * 40, ForceMode.Impulse);
            Destroy(proj_c, 2f);
        }
        if (rock_equ) {
            GameObject proj_R = Instantiate(rkt_Proj, gun_p.transform.position, cam.transform.rotation);
            proj_R.GetComponent<Rigidbody>().AddForce(gun_p.transform.forward * 40, ForceMode.Impulse);
            Destroy(proj_R, 2f);
        }
    }

    IEnumerator trail(TrailRenderer t, Vector3 dir)
    {
        Vector3 Startpos = t.transform.position;
        //var step = bul_speed * Time.deltaTime;
        float distance = Vector3.Distance(gun_p.transform.position, hit.point);
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
