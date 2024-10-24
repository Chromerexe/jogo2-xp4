using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Guns : MonoBehaviour
{

    public PlayerInput ply_in;
    public InputAction fire;
    public InputAction skrl;
    public InputAction chng_wpn1;
    public InputAction chng_wpn2;
    public InputAction chng_wpn3;
    public InputAction chng_wpn4;
    public InputAction last_wpn_in;

    public static int pis_amm = 20;
    public static int shot_amm = 20;
    public static int rock_amm = 5;
    public static int cross_amm = 10;

    public int pis_amm2;
    public int shot_amm2;
    public int rock_amm2;
    public int cross_amm2;

    public static bool has_rkt = false;
    public static bool has_cross = false;
    public static int wpn_amount = 2;

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
    public GameObject gun_p3;
    public GameObject pistol;
    public GameObject shotgun;
    public GameObject rocket;
    public GameObject crossbow;

    public RawImage[] Crosshair;

    public int bullet_amount;
    bool fired = false;

    public GameObject ply;

    public GameObject rkt_Proj;
    public GameObject dart_proj;

    public GameObject hit_ef;
    public GameObject hit_ef_e;
    public RaycastHit hit;

    public int bul_speed;

    public TrailRenderer trl;


    public ParticleSystem[] muzf;

    public Camera cam;

    public LayerMask enemy_mask; 

    void Start()
    {
        
        fire = ply_in.actions["Fired"];
        skrl = ply_in.actions["Scr_wpn"];
        chng_wpn1 = ply_in.actions["Change_wpn1"];
        chng_wpn2 = ply_in.actions["Change_wpn2"];
        chng_wpn3 = ply_in.actions["Change_wpn3"];
        chng_wpn4 = ply_in.actions["Change_wpn4"];
        last_wpn_in = ply_in.actions["Last_wpn"];
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

        pis_amm2 = pis_amm;
        shot_amm2 = shot_amm;
        rock_amm2 = rock_amm;
        cross_amm2 = cross_amm;

        bool atiro = fire.WasPressedThisFrame();
        Vector2 chng= skrl.ReadValue<Vector2>();
        bool change_1 = chng_wpn1.WasPressedThisFrame();
        bool change_2 = chng_wpn2.WasPressedThisFrame();
        bool change_3 = chng_wpn3.WasPressedThisFrame();
        bool change_4 = chng_wpn4.WasPressedThisFrame();
        bool lst_wpn = last_wpn_in.WasPressedThisFrame();

        gun_p.transform.rotation = new Quaternion(-cam.transform.rotation.x, -cam.transform.rotation.y, -cam.transform.rotation.z, -cam.transform.rotation.w);
        gun_p2.transform.rotation = new Quaternion(-cam.transform.rotation.x, -cam.transform.rotation.y, -cam.transform.rotation.z, -cam.transform.rotation.w);
        rb.velocity = transform.forward * 40;
        if(chng.y > 0f && !wpn_curt_switch)
        {
            wpn_curt_switch = true;
            last_wpn = wpn_sel;
            wpn_sel -= 1;
            wpn_curt_switch = false;
        }
        else if (chng.y < 0f && !wpn_curt_switch)
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
        else if (wpn_sel > wpn_amount && !wpn_curt_switch)
        {
            wpn_curt_switch = true;
            wpn_sel = 1;
            wpn_curt_switch = false;
        }

        if(lst_wpn && !wpn_curt_switch)
        {
            wpn_curt_switch = true;
            last_wpn2 = wpn_sel;
            wpn_sel = last_wpn;
            last_wpn = last_wpn2;
            wpn_curt_switch = false;
        }
        if (change_1 && !wpn_curt_switch)
        {
            wpn_curt_switch = true;
            last_wpn = wpn_sel;
            wpn_sel = 1;
            wpn_curt_switch = false;
        }
        if (change_2 && !wpn_curt_switch)
        {
            wpn_curt_switch = true;
            last_wpn = wpn_sel;
            wpn_sel = 2;
            wpn_curt_switch = false;
        }
        if (change_3 && !wpn_curt_switch && has_rkt)
        {
            wpn_curt_switch = true;
            last_wpn = wpn_sel;
            wpn_sel = 3;
            wpn_curt_switch = false;
        }
        if (change_4 && !wpn_curt_switch && has_cross)
        {
            wpn_curt_switch = true;
            last_wpn = wpn_sel;
            wpn_sel = 4;
            wpn_curt_switch = false;
        }
        weapon_selected(wpn_sel);

        
        float timer = 0;
        
        if (pis_equ) {
            if (atiro && timer <=0 && !fired && pis_amm > 0)
            {
                pis_amm -= 1;
                muzf[0].Play();
                shot();
            }
        }
        if (shot_equ) {
            if(shot_amm > 0 && !fired)
            {
                if (atiro && timer <= 0)
                {
                    shot_amm -= 1;
                }
                for (int i = 0; i < bullet_amount; i++)
                {
                    if (atiro && timer <= 0)
                    {
                        muzf[1].Play();
                        shot();
                    }
                }
            }
        }
        if (rock_equ && has_rkt) {
            if (atiro && timer <= 0 && !fired && rock_amm > 0)
            {
                rock_amm -= 1;
                muzf[2].Play();
                shot();
            }
        }
        if (cross_equ && has_cross)
        {
            if (atiro && timer <= 0 && !fired && cross_amm > 0)
            {
                cross_amm -= 1;
                shot();
            }
        }




        //Debug.Log(fired);
    }

    void shot()
    {
        if (pis_equ)
        {
            fired = true;
            StartCoroutine(crosshair());
            
            if (Physics.Raycast(gun_p3.transform.position, gun_p3.transform.forward, out hit, range))
            {

                TrailRenderer spw_trl = Instantiate(trl, gun_p.transform.position, cam.transform.rotation);
                StartCoroutine(trail(spw_trl, hit.point));
                Smol_ene ene1 = hit.transform.GetComponent<Smol_ene>();

                if (ene1 != null)
                {
                    if (Vector3.Distance(ply.transform.position, ene1.transform.position) < 15f)
                    {
                        if (ene1 != null)
                        {
                            ene1.life -= dame;
                            GameObject inpc_e = Instantiate(hit_ef_e, hit.point, Quaternion.LookRotation(hit.normal));
                            Destroy(inpc_e, 2f);
                            Debug.Log(dame);
                        }
                    }
                    else if (Vector3.Distance(ply.transform.position, ene1.transform.position) > 15f)
                    {

                        if (ene1 != null)
                        {
                            ene1.life -= dame/2;
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
            StartCoroutine(cool_dwn());
        }
        if (shot_equ)
        {
            fired = true;
            Vector3 dir = gun_p.transform.forward;
            Vector3 spread = Vector3.zero;
            spread += gun_p.transform.up * Random.Range(-1f, 1f);
            spread += gun_p.transform.right * Random.Range(-1f, 1f);

            dir += spread.normalized * Random.Range(0f, 0.2f);
            if (Physics.Raycast(gun_p3.transform.position, dir, out hit, range))
            {

                TrailRenderer spw_trl = Instantiate(trl, gun_p.transform.position, cam.transform.rotation);
                StartCoroutine(trail(spw_trl, hit.point));
                Smol_ene ene1 = hit.transform.GetComponent<Smol_ene>();
                if (ene1 != null)
                {
                    if (Vector3.Distance(ply.transform.position, ene1.transform.position) < 15f)
                    {
                        if (ene1 != null)
                        {
                            ene1.life -= dame;
                            GameObject inpc_e = Instantiate(hit_ef_e, hit.point, Quaternion.LookRotation(hit.normal));
                            Destroy(inpc_e, 2f);
                            Debug.Log(dame);
                        }
                    }
                    else if (Vector3.Distance(ply.transform.position, ene1.transform.position) > 15f)
                    {

                        if (ene1 != null)
                        {
                            ene1.life -= dame / 2;
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
            StartCoroutine(cool_dwn());
        }
        if (cross_equ && has_cross) {
            fired = true;
            GameObject proj_c = Instantiate(dart_proj, gun_p3.transform.position, cam.transform.rotation);
            proj_c.GetComponent<Rigidbody>().AddForce(gun_p.transform.forward * 40, ForceMode.Impulse);
            Destroy(proj_c, 2f);
            StartCoroutine(cool_dwn());
        }
        if (rock_equ && has_rkt) {
            fired = true;
            GameObject proj_R = Instantiate(rkt_Proj, gun_p3.transform.position, cam.transform.rotation);
            proj_R.GetComponent<Rigidbody>().AddForce(gun_p.transform.forward * 40, ForceMode.Impulse);
            Destroy(proj_R, 2f);
            StartCoroutine(cool_dwn());
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
    IEnumerator cool_dwn()
    {
        if (pis_equ) {
            yield return new WaitForSeconds(0.2f);
            fired = false;
        }
        if (shot_equ)
        {
            yield return new WaitForSeconds(1);
            fired = false;
        }
        if (rock_equ)
        {
            yield return new WaitForSeconds(1);
            fired = false;
        }
        if (cross_equ)
        {
            yield return new WaitForSeconds(0.3f);
            fired = false;
        }
    }
}
