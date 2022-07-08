using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    public Material m;
    public Material mNone;
    public Material mSelected1;
    public Material mSelected2;
    public Material mSet;

    Player[] players;

    Holder holder;
    Hexagon cell;
    MeshRenderer renderer;
    HandManager handManager;
    Calculator calculator;
    int mouseClicked = 0;
    HexDirection direction;


    private void Start()
    {
        holder = FindObjectOfType<Holder>();
        players = FindObjectsOfType<Player>();
        handManager = FindObjectOfType<HandManager>();
        calculator = FindObjectOfType<Calculator>();
        cell = this.gameObject.GetComponent<Hexagon>();
        renderer = this.gameObject.GetComponent<MeshRenderer>();
        mSelected1 = mNone;
        players[0].active = true;
    }

    void Update()
    {
        if (holder.selected)
        {
            mSelected1 = holder.m1;
            mSelected2 = holder.m2;
        } else
        {
            mSelected1 = mNone;
            mSelected2 = mNone;
        }

        if (Input.GetMouseButtonDown(1))
        {
            mouseClicked++;
            switch(mouseClicked){
                case 0:
                    direction = HexDirection.NE;
                    break;
                case 1:
                    direction = HexDirection.E;
                    break;
                case 2:
                    direction = HexDirection.SE;
                    break;
                case 3:
                    direction = HexDirection.SW;
                    break;
                case 4:
                    direction = HexDirection.W;   
                    break;
                case 5:
                    direction = HexDirection.NW;
                    break;
                case 6:
                    direction = HexDirection.NE;
                    mouseClicked = 0;
                    break;

            }
            resetSelection();
        }
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (cell.getNeighbor(direction) != null && !cell.filled && !cell.getNeighbor(direction).filled)
            {
                setTile();
            }
        }
    }

    void OnMouseOver()
    {


        if (cell.getNeighbor(direction) != null && !cell.filled && !cell.getNeighbor(direction).filled)
        {
            renderer.material = mSelected1;
            cell.getNeighbor(direction).GetComponent<MeshRenderer>().material = mSelected2;
        } else
        {
            resetSelection();
        }
    }

    private void OnMouseExit()
    {
        resetSelection();
    }

    private void resetSelection()
    {
        if (cell.getNeighbor(direction) != null && !cell.filled && !cell.getNeighbor(direction).filled)
        {
            renderer.material = m;
            cell.getNeighbor(direction).GetComponent<MeshRenderer>().material = m;
        }
    }

    private void setTile()
    {
        if (holder.selected)
        {
            foreach(Player p in players)
            {
                if (p.active)
                {
                    p.active = false;



                    holder.selected = false;

                    cell.filled = true;
                    cell.getNeighbor(direction).filled = true;

                    renderer.material = mSelected1;
                    cell.getNeighbor(direction).GetComponent<MeshRenderer>().material = mSelected2;

                    handManager.setColor(holder.slot);

                    calculator.calculate(p, cell);
                    calculator.calculate(p, cell.getNeighbor(direction));
                } else if (p.active == false)
                {
                    p.active = true;
                }
            }

        }
    }
}
