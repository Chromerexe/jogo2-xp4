using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Ene_shot : MonoBehaviour
{

    public GameObject gun_p;
    public GameObject gun_p2;
    public RaycastHit hit;
    int range = 200;
    public TrailRenderer trl;
    public int dame;
    public GameObject self;
    public GameObject ply;
    public GameObject hit_ef_e;
    public GameObject hit_ef;

    public LayerMask ply_lm;

    public float timer = 0;

    public Ene_atk Ene;

    // Update is called once per frame
    void Update()
    {

        if (Ene.saw)
        {
            //gun_p.transform.LookAt(ply.transform.position);
            //gun_p2.transform.LookAt(ply.transform.position);
            timer += Time.deltaTime;

            if (timer > 1)
            {

                if (Physics.Raycast(gun_p.transform.position, gun_p.transform.forward, out hit, range, ply_lm))
                {

                    TrailRenderer spw_trl = Instantiate(trl, gun_p2.transform.position, gun_p.transform.rotation);
                    StartCoroutine(trail(spw_trl, hit.point));

                    if(hit.transform.tag == "Player"){
                        Debug.Log("lol");
                        if (Vector3.Distance(self.transform.position, ply.transform.position) < 15f)
                        {
                            if (ply != null)
                            {

                                Player.life -= dame;
                                GameObject inpc_e = Instantiate(hit_ef_e, hit.point, Quaternion.LookRotation(hit.normal));
                                Destroy(inpc_e, 2f);
                            }
                        }
                        else if (Vector3.Distance(self.transform.position, ply.transform.position) > 15f)
                        {

                            if (ply != null)
                            {
                                Player.life -= dame / 2;
                                GameObject inpc_e = Instantiate(hit_ef_e, hit.point, Quaternion.LookRotation(hit.normal));
                                Destroy(inpc_e, 2f);
                            }
                        }
                    }

                    else{
                        GameObject inpc = Instantiate(hit_ef, hit.point, Quaternion.LookRotation(hit.normal));
                        Destroy(inpc, 2f);
                    }
                    
                    
                }
                else
                {
                    TrailRenderer spw_trl = Instantiate(trl, gun_p2.transform.position, gun_p.transform.rotation);
                    StartCoroutine(trail(spw_trl, gun_p.transform.position + gun_p.transform.forward * 50));
                }

                IEnumerator trail(TrailRenderer t, Vector3 dir)
                {
                    Vector3 Startpos = t.transform.position;
                    //var step = bul_speed * Time.deltaTime;
                    float distance = Vector3.Distance(gun_p.transform.position, hit.point);
                    float Rdis = distance;
                    while (Rdis > 0)
                    {
                        t.transform.position = Vector3.Lerp(Startpos, dir, 1 - (Rdis / distance));
                        Rdis -= 100 * Time.deltaTime;
                        yield return null;
                    }
                    Destroy(t.gameObject, trl.time);
                }
                timer = 0;
            }
        }
    }
}
