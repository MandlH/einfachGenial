using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandManager : MonoBehaviour
{

    public GameObject[] slot;
    public Material[] colors;


    void Start()
    {
        setColor();
    }

    private void setColor()
    {
        for (int i = 0; i < slot.Length; i++)
        {
            slot[i].transform.GetChild(0).GetChild(0).GetComponent<MeshRenderer>().material = colors[Random.Range(0, colors.Length)];
            slot[i].transform.GetChild(0).GetChild(1).GetComponent<MeshRenderer>().material = colors[Random.Range(0, colors.Length)];
        }
    }

    public void setColor(GameObject slot)
    {
        slot.transform.GetChild(0).GetComponent<MeshRenderer>().material = colors[Random.Range(0, colors.Length)];
        slot.transform.GetChild(1).GetComponent<MeshRenderer>().material = colors[Random.Range(0, colors.Length)];

        //CAUSE PROTOTYPE
        setColor();
    }
}
