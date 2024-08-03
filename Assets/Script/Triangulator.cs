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
    enum ActiveLiverPart { LL, RL, VC, HP, PV }
    ActiveLiverPart activeLiverPart;

    // spust� se p�i inicializaci p�idru�en�ho objektu( prov�d� se p�ed startem)
    void Awake()
    {
        SetLiverPart();
    }
    // P�i�azen� sou�asn�mu LiverPart typ a vytvo�en� instance, n�sledn� p�id�n� Bu�ek do dan�ho list ��sti jater
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
                    // napln�n� sou�asn� ��sti jater bu�kami( bu�ka = 3 Vertexy, materi�l)
                    Cell = new Cell(meshTrianglesVertices[i]);
                    Liver.LeftLobe.hepatotyteCells.Add(Cell);
                }
                activeLiverPart = ActiveLiverPart.LL;

                break;
            case ("Right_Lobe"):
                Liver.RightLobe = new LobeLiverPart();
                ParseMeshToTriangles(meshTrianglesVertices);
                for (int i = 0; i < meshTrianglesVertices.Count; i++)
                {
                    // napln�n� currentLiverPart bu�kami( bu�ka = 3 Vertexy)
                    Cell = new Cell(meshTrianglesVertices[i]);
                    Liver.RightLobe.hepatotyteCells.Add(Cell);
                }
                activeLiverPart = ActiveLiverPart.RL;
                break;
            case ("Vena_Canva"):
                Liver.VenaCanva = new VeinLiverPart();
                ParseMeshToTriangles(meshTrianglesVertices);
                for (int i = 0; i < meshTrianglesVertices.Count; i++)
                {
                    // napln�n� currentLiverPart bu�kami( bu�ka = 3 Vertexy)
                    Cell = new Cell(meshTrianglesVertices[i]);
                    Liver.VenaCanva.veinCells.Add(Cell);
                }
                activeLiverPart = ActiveLiverPart.VC;
                break;
            case ("Hepatic_Portal"):
                Liver.HepaticPortal = new VeinLiverPart();
                ParseMeshToTriangles(meshTrianglesVertices);
                for (int i = 0; i < meshTrianglesVertices.Count; i++)
                {
                    // napln�n� currentLiverPart bu�kami( bu�ka = 3 Vertexy)
                    Cell = new Cell(meshTrianglesVertices[i]);
                    Liver.HepaticPortal.veinCells.Add(Cell);
                }
                activeLiverPart = ActiveLiverPart.HP;
                break;
            case ("Portal_Vein"):
                Liver.PortalVein = new VeinLiverPart();
                ParseMeshToTriangles(meshTrianglesVertices);
                for (int i = 0; i < meshTrianglesVertices.Count; i++)
                {
                    // napln�n� currentLiverPart bu�kami( bu�ka = 3 Vertexy)
                    Cell = new Cell(meshTrianglesVertices[i]);
                    Liver.PortalVein.veinCells.Add(Cell);
                }
                activeLiverPart = ActiveLiverPart.PV;
                break;
            default:
                Debug.LogError(" Wrong LiverPart name or not set");
                return;

        }
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

        if (MeshFilter == null)
        {
            Debug.LogError("MeshFilter not found!");
            return;
        }
        CellTriangle = new CellTriangle(Material, transform, GameLiverPart.tag);
        Cell cell;
        // projit� v�ek bu�ek v LiverPart a jejich vykreslen�
        LiverPart part = null;
        switch (activeLiverPart)
        {
            case (ActiveLiverPart.LL):
                part = Liver.LeftLobe;

                break;
            case (ActiveLiverPart.RL):
                part = Liver.RightLobe;

                break;
            case (ActiveLiverPart.VC):
                part = Liver.VenaCanva;

                break;
            case (ActiveLiverPart.HP):
                part = Liver.HepaticPortal;

                break;
            case (ActiveLiverPart.PV):
                part = Liver.PortalVein;
                break;

            default:
                Debug.LogError("Nejsou nastaven� ��sti jater �i �patn� n�zev");
                break;
        }

        for (int i = 0; i < part.GetAllCells().Count; i++)
        {
            cell = part.GetAllCells()[i];
            CellTriangle.SetCell(cell);
            CellTriangle.AddTriangleToScene(cell.GetPoints());
        }
    }
    private void Update()
    {
       // ChangeCell();
    }
    private void ChangeCell()
    {
        // test method for changing cell

        // pole int�( 0 index  , 1 ��st jater(0left,1right))
        int[] indicies = Liver.GetRandomLobeCellIndiciesByType(Cell.CellType.HEPATOCYTE);
        var rend = GameLiverPart.GetComponent<Renderer>();
        Material material = Resources.Load("Materials/Fat") as Material;
        
        // p�e�azen� bu�ky do jin�ho seznamu
        if (indicies[1] == 0)
        {
            Cell cell = Liver.LeftLobe.hepatotyteCells[indicies[0]];

            // odstran�n� 
            //CellTriangle.RemoveTriangleFromScene(cell);
            cell.SetTriangleMaterial(material);

            Liver.LeftLobe.ChangeCell(Cell.CellType.HEPATOCYTE, Cell.CellType.FAT, indicies[0]);
        }
        else if (indicies[1] == 1)
        {
            Cell cell = Liver.RightLobe.hepatotyteCells[indicies[0]];
            cell.SetTriangleMaterial(material);
            //CellTriangle.RemoveTriangleFromScene(cell);
            Liver.RightLobe.ChangeCell(Cell.CellType.HEPATOCYTE, Cell.CellType.FAT, indicies[0]);
        }
        //CellTriangle = new CellTriangle(Mesh, Material, transform, GameLiverPart.tag);


    }

}

