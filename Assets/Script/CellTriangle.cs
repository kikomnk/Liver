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
    LiverCell cell;

    //private List<Vector3> verts;

    public CellTriangle( Material material, Transform transform, string tag)
    {
              
        this.material = material;
        this.tag = tag;
        this.transform = transform;  
      
    }
    public void SetCell(LiverCell cell) { this.cell = cell; }

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
        

        if (tag == "Lobe" )
        {
            triangle.tag = "Cell";

        }
        else { triangle.tag = "Vein"; }
        var collider = triangle.AddComponent<Rigidbody2D>();
        collider.isKinematic = true;
        var handler = triangle.AddComponent<CollisionHandler>();
        //handler.OnCollisionDetected += collider
        cell.SetTriangle(triangle);
    }
    public void RemoveTriangleFromScene(LiverCell cell)
    {
        // GameObject.Destroy(cell.GetTriangle());
      //  cell.SetTriangleMaterial(material);

    }

    /*
    private GameObject FindTriangle(Vector3[] vertices) 
    {
        foreach (GameObject triangle in Liver.LeftLobe.hepatotyteCells[1].trian)
    }
    */
}
