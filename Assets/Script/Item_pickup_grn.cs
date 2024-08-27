using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item_pickup_grn : MonoBehaviour
{
    bool item_got;
    public Transform item_pick;
    public float item_d;
    public LayerMask ply;

    public Image item_ui;

    void Start()
    {
        item_ui.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        bool item_got = Physics.CheckSphere(item_pick.position, item_d, ply);
        if (item_got)
        {
            Player.grn_card = true;
            item_ui.enabled = true;
            Destroy(this.gameObject);
        }
    }
}
