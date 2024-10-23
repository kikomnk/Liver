using System.Collections.Generic;
using UnityEngine;

public class Controlls : MonoBehaviour
{
    GutPoint gutPoint = new GutPoint();
    private KeyCode drinkBeerKey = KeyCode.Keypad1;
    private KeyCode transpharency = KeyCode.Keypad9;
    bool isVisible = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(drinkBeerKey))
            gutPoint.DrinkBeer();
        if (Input.GetKeyDown(transpharency)) {    
            
            if (isVisible) { ChangeCellsToTransparent(); }
            else if (!isVisible) { ResetAllCellMaterials(); }
            isVisible = !isVisible;

        };
        ChangeCell();
           
    }
    // set all cells material to transpharent
    private void ChangeCellsToTransparent()
    {
        for (int i = 0; i < Liver.GetNOfCells(); i++) 
        {
            Material material = Resources.Load("Materials/Alfa") as Material;

            LiverCell cell = Liver.GetAllLiverCells()[i];
            cell.SetTriangleMaterial(material);
        }
    }
    // reset materials to default
    private void ResetAllCellMaterials()
    {     
        List<LiverCell> currentList = new List<LiverCell>();
        for (int i = 0; i < 6; i++)
        {
            switch (i)
            {
                case 0:
                    currentList = Liver.hepatotyteCells;
                    for (int j = 0; j < currentList.Count; j++)
                    {
                        LiverCell liverCell = currentList[j];
                        liverCell.SetTriangleMaterial(Resources.Load("Materials/Hepatocyte") as Material);
                    }
                    break;
                case 1:
                    currentList = Liver.fatCells;
                    for (int j = 0; j < currentList.Count; j++)
                    {
                        LiverCell liverCell = currentList[j];
                        liverCell.SetTriangleMaterial(Resources.Load("Materials/Fat") as Material);
                    }
                    break;
                case 2:
                    currentList = Liver.damagedHepatotyteCells;
                    for (int j = 0; j < currentList.Count; j++)
                    {
                        LiverCell liverCell = currentList[j];
                        liverCell.SetTriangleMaterial(Resources.Load("Materials/Damaged Hepatocyte") as Material);
                    }
                    break;
                case 3:
                    currentList = Liver.fibrosisCells;
                    for (int j = 0; j < currentList.Count; j++)
                    {
                        LiverCell liverCell = currentList[j];
                        liverCell.SetTriangleMaterial(Resources.Load("Materials/Fibrosis") as Material);
                    }
                    break;
                case 4:
                    currentList = Liver.cirhosisCells;
                    for (int j = 0; j < currentList.Count; j++)
                    {
                        LiverCell liverCell = currentList[j];
                        liverCell.SetTriangleMaterial(Resources.Load("Materials/Cirhosis") as Material);
                    }
                    break;
                case 5:
                    currentList = Liver.veinCells;
                    for (int j = 0; j < currentList.Count; j++)
                    {
                        LiverCell liverCell = currentList[j];
                        liverCell.SetTriangleMaterial(Resources.Load("Materials/Vein") as Material);
                    }
                    break;
            };
           
        }
            
    }

    private void ChangeCell()
    {
        // test method for changing cell     
        int index = Liver.GetRandomLiverCellByType(LiverCell.CellType.HEPATOCYTE);
        //var rend = GameLiverPart.GetComponent<Renderer>();
        Material material = Resources.Load("Materials/Fat") as Material;

        LiverCell cell = Liver.hepatotyteCells[index];
        // if Cells should be visible, They change material
        if (isVisible) { cell.SetTriangleMaterial(material); }

        //CellTriangle.RemoveTriangleFromScene(cell);
        // pøeøazení buòky do jiného seznamu
        Liver.ChangeCell(LiverCell.CellType.HEPATOCYTE, LiverCell.CellType.FAT, index);

        //CellTriangle = new CellTriangle(Mesh, Material, transform, GameLiverPart.tag);


    }

}
