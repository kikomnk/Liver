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
    //používá se poro pøenesení informace o tom která èát jater to je pro Start;

    // spustí se pøi inicializaci pøidruženého objektu( provádí se pøed startem)
    void Awake()
    {
        SetLiver();
    }
    // Pøiøazení souèasnému LiverPart typ a vytvoøení instance, následnì pøidání Buòek do daného list èásti jater
    void SetLiver()
    {
        List<Vector3[]> meshTrianglesVertices = new List<Vector3[]>();
        LiverCell Cell;
        CellTriangle = new CellTriangle(Material, transform, GameLiverPart.tag);

        ParseMeshToTriangles(meshTrianglesVertices);

        for (int i = 0; i < meshTrianglesVertices.Count; i++)
        {
            // naplnìní currentLiverPart buòkami( buòka = 3 Vertexy)
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

        // zrušení pùvodního meshe
        GetComponent<MeshRenderer>().enabled = false;

    }
    private List<Vector3[]> ParseMeshToTriangles(List<Vector3[]> meshTriangleVertices)
    {
        // list souøadnic vertexù trojúhelníkù

        MeshFilter = GetComponent<MeshFilter>();
        Mesh = MeshFilter.mesh;
        Vector3[] vertices = Mesh.vertices;
        int[] triangles = Mesh.triangles;
        

        //projití všech trojúhelníkù daného meshe
        for (int i = 0; i < triangles.Length; i += 3)
        {

            //pøiøazení bodù trojúhelníku z meshe do seznamu
            Vector3[] triangleVertices = new Vector3[3];
            triangleVertices[0] = vertices[triangles[i]];
            triangleVertices[1] = vertices[triangles[i + 1]];
            triangleVertices[2] = vertices[triangles[i + 2]];
            

            meshTriangleVertices.Add(triangleVertices);

        }
        return meshTriangleVertices;

        // Zrušení pùvodního meshe

    }
    // pøi startu Aplikace
    private void Start()
    {


    }
    private void Update()
    {
       
    }
 

}

