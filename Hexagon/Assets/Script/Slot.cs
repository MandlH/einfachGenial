using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    GameObject m1;
    GameObject m2;
    Holder holder;

    private void Start()
    {
        m1 = this.gameObject.transform.GetChild(0).gameObject;
        m2 = this.gameObject.transform.GetChild(1).gameObject;
        holder = FindObjectOfType<Holder>();
    }

    private void OnMouseOver()
    {
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            select();
        }
    }

    private void select()
    {
        holder.m1 = m1.GetComponent<MeshRenderer>().material;
        holder.m2 = m2.GetComponent<MeshRenderer>().material;
        holder.slot = this.gameObject;
        holder.selected = true;
    }
}
