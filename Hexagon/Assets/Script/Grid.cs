using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
	public int width = 6;
	public int height = 6;

	public Hexagon cellPrefab;

	Hexagon[] cells;

	void Awake()
	{
		cells = new Hexagon[height * width];


		for (int z = 0, i = 0; z < height; z++)
		{
			for (int x = 0; x < width; x++)
			{
				createCell(x, z, i++);
			}

		}
	}

	void createCell(int x, int z, int i)
	{


		Vector3 position;
		position.x = (x + z * 0.5f - z / 2) * (HexagonMetrics.innerRadius);
	    position.y = 0f;
		position.z = z * (HexagonMetrics.outerRadius * 0.75f);

		Hexagon cell = cells[i] = Instantiate<Hexagon>(cellPrefab);
		cell.transform.SetParent(transform, false);
		cell.transform.position = position;


		setNeighbors(cell, x, z, i);
		

	}

	void setNeighbors(Hexagon cell, int x, int z, int i)
    {
		if (x > 0)
		{
			cell.setNeighbor(HexDirection.W, cells[i - 1]);
		}
		if (z > 0)
		{
			if ((z & 1) == 0)
			{
				cell.setNeighbor(HexDirection.SE, cells[i - width]);
				if (x > 0)
				{
					cell.setNeighbor(HexDirection.SW, cells[i - width - 1]);
				}
			}
			else
			{
				cell.setNeighbor(HexDirection.SW, cells[i - width]);
				if (x < width - 1)
				{
					cell.setNeighbor(HexDirection.SE, cells[i - width + 1]);
				}
			}
		}
	}

}
