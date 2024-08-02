using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateCellPosition : MonoBehaviour
{
    [field: SerializeField] public GameObject LiverPart { get; set; }
    


    // Start is called before the first frame update
    void Start()
    {
        
        //CalculatePosition();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
   /* void CalculatePosition ()
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        if (meshFilter == null)
        {
            Debug.LogError("MeshFilter not found!");
            return;
        }
        
        Mesh mesh = meshFilter.mesh;
        Vector3[] vertices = mesh.vertices;
        int[] triangles = mesh.triangles;

        //aktuální tìžištì
        Vector3 centroid = new Vector3();
        
        //Liver.cells = new List<Cell>();
        for (int i = 0; i < vertices.Length; i ++)
        {
            
            Cell cell = new Cell(vertices[i],LiverPart);
            Liver.cells.Add(cell);
            

        }
        Debug.Log(Liver.GetNOfCells().ToString());
        for (int i = 0; i < triangles.Length; i += 3)
        {


            // vypoèítání tìžištì

            centroid.x = (vertices[triangles[i]].x + vertices[triangles[i + 1]].x + vertices[triangles[i + 2]].x) / 3;
            centroid.y = (vertices[triangles[i]].y + vertices[triangles[i + 1]].y + vertices[triangles[i + 2]].y) / 3;
            centroid.z = (vertices[triangles[i]].z + vertices[triangles[i + 1]].z + vertices[triangles[i + 2]].z) / 3;
            

            Cell cell = new Cell(centroid,LiverPart);
            Liver.cells.Add(cell);



        }


    }
   */

}
