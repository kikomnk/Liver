using System.Collections.Generic;
using UnityEngine;

public class Triangulator : MonoBehaviour
{
    [field: SerializeField] public Material Material { get; set; }
    [field: SerializeField] public GameObject GameLiverPart { get; set; }

    Mesh Mesh;
    CellTriangle CellTriangle;
    MeshFilter MeshFilter;
    //active LiverPart
    //pou��v� se poro p�enesen� informace o tom kter� ��t jater to je pro Start;

    // spust� se p�i inicializaci p�idru�en�ho objektu( prov�d� se p�ed startem)
    void Awake()
    {
        SetLiver();
    }
    // P�i�azen� sou�asn�mu LiverPart typ a vytvo�en� instance, n�sledn� p�id�n� Bu�ek do dan�ho list ��sti jater
    void SetLiver()
    {
        List<Vector3[]> meshTrianglesVertices = new List<Vector3[]>();
        LiverCell Cell;
        CellTriangle = new CellTriangle(Material, transform, GameLiverPart.tag);

        ParseMeshToTriangles(meshTrianglesVertices);

        for (int i = 0; i < meshTrianglesVertices.Count; i++)
        {
            // napln�n� currentLiverPart bu�kami( bu�ka = 3 Vertexy)
            Cell = new LiverCell(meshTrianglesVertices[i]);
            if (GameLiverPart.CompareTag("Lobe"))
            {
                Liver.hepatotyteCells.Add(Cell);
            }
            else
            {
                Liver.veinCells.Add(Cell);
            }
            CellTriangle.SetCell(Cell);
            CellTriangle.AddTriangleToScene(Cell.GetPoints());

        }
       CellTriangle = new CellTriangle(Material, transform, GameLiverPart.tag);

        // zru�en� p�vodn�ho meshe
        GetComponent<MeshRenderer>().enabled = false;

    }
    private List<Vector3[]> ParseMeshToTriangles(List<Vector3[]> meshTriangleVertices)
    {
        // list sou�adnic vertex� troj�heln�k�

        MeshFilter = GetComponent<MeshFilter>();
        Mesh = MeshFilter.mesh;
        Vector3[] vertices = Mesh.vertices;
        int[] triangles = Mesh.triangles;
        

        //projit� v�ech troj�heln�k� dan�ho meshe
        for (int i = 0; i < triangles.Length; i += 3)
        {

            //p�i�azen� bod� troj�heln�ku z meshe do seznamu
            Vector3[] triangleVertices = new Vector3[3];
            triangleVertices[0] = vertices[triangles[i]];
            triangleVertices[1] = vertices[triangles[i + 1]];
            triangleVertices[2] = vertices[triangles[i + 2]];
            

            meshTriangleVertices.Add(triangleVertices);

        }
        return meshTriangleVertices;

        // Zru�en� p�vodn�ho meshe

    }
    // p�i startu Aplikace
    private void Start()
    {


    }
    private void Update()
    {
       
    }
 

}

