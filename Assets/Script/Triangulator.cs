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
    enum ActiveLiverPart { LL, RL, VC, HP, PV }
    ActiveLiverPart activeLiverPart;

    // spustí se pøi inicializaci pøidruženého objektu( provádí se pøed startem)
    void Awake()
    {
        SetLiverPart();
    }
    // Pøiøazení souèasnému LiverPart typ a vytvoøení instance, následnì pøidání Buòek do daného list èásti jater
    void SetLiverPart()
    {
        List<Vector3[]> meshTrianglesVertices = new List<Vector3[]>();
        Cell Cell;
        switch (GameLiverPart.name)
        {
            case ("Left_Lobe"):
                Liver.LeftLobe = new LobeLiverPart();
                ParseMeshToTriangles(meshTrianglesVertices);
                for (int i = 0; i < meshTrianglesVertices.Count; i++)
                {
                    // naplnìní souèasné Èásti jater buòkami( buòka = 3 Vertexy, materiál)
                    Cell = new Cell(meshTrianglesVertices[i], Material);
                    Liver.LeftLobe.hepatotyteCells.Add(Cell);
                }
                activeLiverPart = ActiveLiverPart.LL;

                break;
            case ("Right_Lobe"):
                Liver.RightLobe = new LobeLiverPart();
                ParseMeshToTriangles(meshTrianglesVertices);
                for (int i = 0; i < meshTrianglesVertices.Count; i++)
                {
                    // naplnìní currentLiverPart buòkami( buòka = 3 Vertexy)
                    Cell = new Cell(meshTrianglesVertices[i], Material);
                    Liver.RightLobe.hepatotyteCells.Add(Cell);
                }
                activeLiverPart = ActiveLiverPart.RL;
                break;
            case ("Vena_Canva"):
                Liver.VenaCanva = new VeinLiverPart();
                ParseMeshToTriangles(meshTrianglesVertices);
                for (int i = 0; i < meshTrianglesVertices.Count; i++)
                {
                    // naplnìní currentLiverPart buòkami( buòka = 3 Vertexy)
                    Cell = new Cell(meshTrianglesVertices[i], Material);
                    Liver.VenaCanva.veinCells.Add(Cell);
                }
                activeLiverPart = ActiveLiverPart.VC;
                break;
            case ("Hepatic_Portal"):
                Liver.HepaticPortal = new VeinLiverPart();
                ParseMeshToTriangles(meshTrianglesVertices);
                for (int i = 0; i < meshTrianglesVertices.Count; i++)
                {
                    // naplnìní currentLiverPart buòkami( buòka = 3 Vertexy)
                    Cell = new Cell(meshTrianglesVertices[i], Material);
                    Liver.HepaticPortal.veinCells.Add(Cell);
                }
                activeLiverPart = ActiveLiverPart.HP;
                break;
            case ("Portal_Vein"):
                Liver.PortalVein = new VeinLiverPart();
                ParseMeshToTriangles(meshTrianglesVertices);
                for (int i = 0; i < meshTrianglesVertices.Count; i++)
                {
                    // naplnìní currentLiverPart buòkami( buòka = 3 Vertexy)
                    Cell = new Cell(meshTrianglesVertices[i], Material);
                    Liver.PortalVein.veinCells.Add(Cell);
                }
                activeLiverPart = ActiveLiverPart.PV;
                break;
            default:
                Debug.LogError(" Wrong LiverPart name or not set");
                return;

        }
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

        if (MeshFilter == null)
        {
            Debug.LogError("MeshFilter not found!");
            return;
        }
        CellTriangle = new CellTriangle(Material, transform, GameLiverPart.tag);
        Cell cell;
        // projití všek buòek v LiverPart a jejich vykreslení
        switch (activeLiverPart)
        {
            case (ActiveLiverPart.LL):
                for (int i = 0; i < Liver.LeftLobe.GetAllCells().Count; i++)
                {
                    cell = Liver.LeftLobe.GetAllCells()[i];
                    // oøiøazení do Buòky GameObject trojúhelník
                    CellTriangle.SetCell(cell);
                    CellTriangle.AddTriangleToScene(cell.GetPoints());


                }
                break;
            case (ActiveLiverPart.RL):
                for (int i = 0; i < Liver.RightLobe.GetAllCells().Count; i++)
                {

                    cell = Liver.RightLobe.GetAllCells()[i];
                    CellTriangle.SetCell(cell);
                    CellTriangle.AddTriangleToScene(cell.GetPoints());

                }
                break;
            case (ActiveLiverPart.VC):
                for (int i = 0; i < Liver.VenaCanva.GetAllCells().Count; i++)
                {

                    cell = Liver.VenaCanva.GetAllCells()[i];
                    CellTriangle.SetCell(cell);
                    CellTriangle.AddTriangleToScene(cell.GetPoints());

                }
                break;
            case (ActiveLiverPart.HP):
                for (int i = 0; i < Liver.HepaticPortal.GetAllCells().Count; i++)
                {

                    cell = Liver.HepaticPortal.GetAllCells()[i];
                    CellTriangle.SetCell(cell);
                    CellTriangle.AddTriangleToScene(cell.GetPoints());

                }
                break;
            case (ActiveLiverPart.PV):
                for (int i = 0; i < Liver.PortalVein.GetAllCells().Count; i++)
                {

                    cell = Liver.PortalVein.GetAllCells()[i];
                    CellTriangle.SetCell(cell);
                    CellTriangle.AddTriangleToScene(cell.GetPoints());

                }
                break;
            default:
                Debug.LogError("Nejsou nastavené èásti jater èi špatný název");
                break;

        }



    }
    private void Update()
    {
        ChangeCell();
    }
    private void ChangeCell()
    {
        // test method for changing cell

        // pole intù( 0 index  , 1 èást jater(0left,1right))
        int[] indicies = Liver.GetRandomLobeCellIndiciesByType(Cell.CellType.HEPATOCYTE);

        // pøeøazení buòky do jiného seznamu
        if (indicies[1] == 0)
        {

            Cell cell = Liver.LeftLobe.hepatotyteCells[indicies[0]];

            // odstranìní 
            CellTriangle.RemoveTriangleFromScene(cell);


            Liver.LeftLobe.ChangeCell(Cell.CellType.HEPATOCYTE, Cell.CellType.FAT, indicies[0]);


        }
        else if (indicies[1] == 1)
        {
            Cell cell = Liver.RightLobe.hepatotyteCells[indicies[0]];
            CellTriangle.RemoveTriangleFromScene(cell);
            Liver.RightLobe.ChangeCell(Cell.CellType.HEPATOCYTE, Cell.CellType.FAT, indicies[0]);


        }
        //CellTriangle = new CellTriangle(Mesh, Material, transform, GameLiverPart.tag);


    }

}

