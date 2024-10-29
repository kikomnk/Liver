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

        // Mesh pro renderování
        Mesh mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.triangles = new int[] { 0, 1, 2 };
        mesh.RecalculateNormals();

        MeshFilter meshFilter = triangle.AddComponent<MeshFilter>();
        meshFilter.mesh = mesh;

        MeshRenderer meshRenderer = triangle.AddComponent<MeshRenderer>();
        meshRenderer.material = material;

        // Mesh pro kolize
        Mesh colliderMesh = new Mesh();
        colliderMesh.vertices = vertices;
        // Pøidáme trojúhelníkový collider s vrcholy 2,1,0, aby mìl collider normálu dovnitø pro správné fungování kolizí
        colliderMesh.triangles = new int[] { 2, 1, 0 };
        colliderMesh.RecalculateNormals();

        MeshCollider coll = triangle.AddComponent<MeshCollider>();
        coll.sharedMesh = colliderMesh;
        // Ujistíme se, že collider není konvexní
        coll.convex = false;



        var body = triangle.AddComponent<Rigidbody>();
        body.isKinematic = true;

        if (tag == "Lobe")
        {
            triangle.tag = "Cell";
            triangle.layer = 3;
        }
        else
        {
            triangle.tag = "Vein";
        }

        cell.SetTriangle(triangle);
    }
}
