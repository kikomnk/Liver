using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CellTriangle
{
    //tøída pro vykreslení trojùhelníku    
    private Material material;
    private string tag;
    Transform transform;
    Cell cell;

    //private List<Vector3> verts;

    public CellTriangle( Material material, Transform transform, string tag)
    {
              
        this.material = material;
        this.tag = tag;
        this.transform = transform;  
      
    }
    public void SetCell(Cell cell) { this.cell = cell; }

    public void AddTriangleToScene(Vector3[] vertices)
    {
        GameObject triangle = new GameObject("Triangle");
        triangle.transform.SetParent(transform);

        Mesh mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.triangles = new int[] { 0, 1, 2 };
        mesh.RecalculateNormals();

        MeshFilter meshFilter = triangle.AddComponent<MeshFilter>();
        meshFilter.mesh = mesh;

        MeshRenderer meshRenderer = triangle.AddComponent<MeshRenderer>();


        meshRenderer.material = material;
        

        if (tag == "Left_Lobe" || tag == "Right_Lobe")
        {
            triangle.tag = "Cell";

        }
        else { triangle.tag = "Vein"; }
        triangle.AddComponent<MeshCollider>();
        cell.SetTriangle(triangle);
    }
    public void RemoveTriangleFromScene(Cell cell)
    {
        GameObject.Destroy(cell.GetTriangle());
    }
    public void SetTriangleMaterial(Material material)
    {
        this.material = material;
    }
    /*
    private GameObject FindTriangle(Vector3[] vertices) 
    {
        foreach (GameObject triangle in Liver.LeftLobe.hepatotyteCells[1].trian)
    }
    */
}
