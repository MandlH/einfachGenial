using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calculator : MonoBehaviour
{
    private Hexagon hex;
    private HandManager handManager;
    public Player p1;

    private void Awake()
    {
        handManager = FindObjectOfType<HandManager>();
    }


    public void calculate(Player p , Hexagon cell)
    {
        this.hex = cell;
        //TODO
        for(int i = 0; i < 6; i++)
        {
            switch (i)
            {
                case 0:
                    respCalc(p, cell, HexDirection.E);
                    break;
                case 1:
                    respCalc(p, cell, HexDirection.NE);
                    break;
                case 2:
                    respCalc(p, cell, HexDirection.NW);
                    break;
                case 3:
                    respCalc(p, cell, HexDirection.SE);
                    break;
                case 4:
                    respCalc(p, cell, HexDirection.SW);
                    break;
                case 5:
                    respCalc(p, cell, HexDirection.W);
                    break;
            }
        }
    }

    public void respCalc(Player p, Hexagon cell, HexDirection direction)
    {

        if (!cell.Equals(this.hex))
        {
            if (cell.GetComponent<MeshRenderer>().material.color == handManager.colors[0].color)
                p.blue++;
            else if (cell.GetComponent<MeshRenderer>().material.color == handManager.colors[1].color)
                p.green++;
            else if (cell.GetComponent<MeshRenderer>().material.color == handManager.colors[2].color)
                p.red++;
            else if (cell.GetComponent<MeshRenderer>().material.color == handManager.colors[3].color)
                p.purble++;
            else if (cell.GetComponent<MeshRenderer>().material.color == handManager.colors[4].color)
                p.yellow++;

        }

        if (cell.getNeighbor(direction) != null && 
            cell.getNeighbor(direction).GetComponent<MeshRenderer>().material.color == this.hex.GetComponent<MeshRenderer>().material.color)
            respCalc(p, cell.getNeighbor(direction), direction);
    }


}
