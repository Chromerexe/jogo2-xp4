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
    public Image item_ui2;

    void Start()
    {
        item_ui.enabled = false;
        item_ui2.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        bool item_got = Physics.CheckSphere(item_pick.position, item_d, ply);
        if (item_got)
        {
            Player.grn_card = true;
            if (item_ui.color == Color.blue)
            {
                item_ui2.color = Color.green;
                item_ui2.enabled = true;
            }
            else
            {
                item_ui.color = Color.green;
                item_ui.enabled = true;
            }
            Destroy(this.gameObject);
        }
    }
}
