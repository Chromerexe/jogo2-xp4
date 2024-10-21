using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Ene_shot : MonoBehaviour
{

    public GameObject gun_p;
    public GameObject gun_p2;
    public RaycastHit hit;
    int range = 20;
    public TrailRenderer trl;
    public int dame;
    public GameObject self;
    public GameObject ply;
    public GameObject hit_ef_e;
    public GameObject hit_ef;

    public float timer = 0;

    public Ene_atk Ene;

    // Update is called once per frame
    void Update()
    {

        if (Ene.saw)
        {
            gun_p2.transform.rotation = Quaternion.RotateTowards(gun_p2.transform.rotation, ply.transform.rotation, 20);
            timer += Time.deltaTime;

            if (timer > 5)
            {
                bool fired = true;

                if (Physics.Raycast(gun_p.transform.position, gun_p.transform.forward, out hit, range))
                {

                    TrailRenderer spw_trl = Instantiate(trl, gun_p2.transform.position, gun_p.transform.rotation);
                    StartCoroutine(trail(spw_trl, hit.point));
                    Player ene1 = hit.transform.GetComponent<Player>();

                    if (ene1 != null)
                    {
                        if (Vector3.Distance(self.transform.position, ene1.transform.position) < 15f)
                        {
                            if (ene1 != null)
                            {

                                Player.life -= dame;
                                GameObject inpc_e = Instantiate(hit_ef_e, hit.point, Quaternion.LookRotation(hit.normal));
                                Destroy(inpc_e, 2f);
                            }
                        }
                        else if (Vector3.Distance(self.transform.position, ene1.transform.position) > 15f)
                        {

                            if (ene1 != null)
                            {
                                Player.life -= dame / 2;
                                GameObject inpc_e = Instantiate(hit_ef_e, hit.point, Quaternion.LookRotation(hit.normal));
                                Destroy(inpc_e, 2f);
                            }
                        }
                    }

                    else
                    {
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
