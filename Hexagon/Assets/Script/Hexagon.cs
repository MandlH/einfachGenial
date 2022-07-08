using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class Hexagon : MonoBehaviour
{

    public Hexagon[] neighbors;
    public bool filled = false;

    Mesh hexMesh;
    List<int> triangles;
    List<Vector3> vertices;





    private void Awake(){
        GetComponent<MeshFilter>().mesh = hexMesh = new Mesh();
        MeshCollider collider =  this.gameObject.AddComponent<MeshCollider>();
        hexMesh.name = "Hex Mesh";
        vertices = new List<Vector3>();
        triangles = new List<int>();
    }

    private void Start()
    {       
        triangulate();
    }

    private void triangulate(){
        hexMesh.Clear();
        vertices.Clear();
        triangles.Clear();
        Vector3 center = this.transform.localPosition;
        for (int i = 0; i < 6; i++)
        {
            addTriangle(
                center,
                center + HexagonMetrics.corners[i],
                center + HexagonMetrics.corners[i + 1]
            );
        }
        hexMesh.vertices = vertices.ToArray();
        hexMesh.triangles = triangles.ToArray();
        hexMesh.RecalculateNormals();
        this.gameObject.GetComponent<MeshCollider>().convex = true;
    }

    private void addTriangle(Vector3 v1, Vector3 v2, Vector3 v3){
        int vertexIndex = vertices.Count;
        vertices.Add(v1);
        vertices.Add(v2);
        vertices.Add(v3);
        triangles.Add(vertexIndex);
        triangles.Add(vertexIndex + 1);
        triangles.Add(vertexIndex + 2);
    }


    public Hexagon getNeighbor(HexDirection direction)
    {
        return neighbors[(int)direction];
    }

    public void setNeighbor(HexDirection direction, Hexagon cell)
    {
        neighbors[(int)direction] = cell;
        cell.neighbors[(int)direction.Opposite()] = this;
    }
}
