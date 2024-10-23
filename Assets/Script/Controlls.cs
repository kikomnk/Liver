using System.Collections.Generic;
using UnityEngine;

public class Controlls : MonoBehaviour
{
    GutPoint gutPoint = new GutPoint();
    private KeyCode drinkBeerKey = KeyCode.Keypad1;
    private KeyCode transpharency = KeyCode.Keypad9;
    bool timer = true;
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
            
            if (timer) { ChangeCellsToTransparent(); }
            else if (!timer) { ResetAllCellsMaterial(); }
            timer = !timer;

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
    private void ResetAllCellsMaterial()
    {
        /*
        List<LiverCell> currentList = new List<LiverCell>();
        for (int i = 0; i < 6; i++)
        {
            
        }
        
    Liver.GetListByType(LiverCell.CellType.Hepatocyte)
        
        */
    
    }
    private void ChangeCell()
    {
        // test method for changing cell     
        int index = Liver.GetRandomLiverCellByType(LiverCell.CellType.HEPATOCYTE);
        //var rend = GameLiverPart.GetComponent<Renderer>();
        Material material = Resources.Load("Materials/Fat") as Material;

        LiverCell cell = Liver.hepatotyteCells[index];
        if (timer) { cell.SetTriangleMaterial(material); }

        //CellTriangle.RemoveTriangleFromScene(cell);
        // pøeøazení buòky do jiného seznamu
        Liver.ChangeCell(LiverCell.CellType.HEPATOCYTE, LiverCell.CellType.FAT, index);

        //CellTriangle = new CellTriangle(Mesh, Material, transform, GameLiverPart.tag);


    }

}
