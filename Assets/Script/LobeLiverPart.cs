using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobeLiverPart : LiverPart
{
    public PartType partType = PartType.LOBE;
    public enum Part {LEFT_LOBE, RIGHT_LOBE };
    public Part part;
    public List<Cell> hepatotyteCells, fatCells, damagedHepatotyteCells, fibrosisCells, cirhosisCells;
   // System.Random Random = new System.Random();
    public LobeLiverPart() 
    {
        hepatotyteCells = new List<Cell>();
        fatCells = new List<Cell>();
        damagedHepatotyteCells = new List<Cell>();
        fibrosisCells = new List<Cell>();
        cirhosisCells = new List<Cell>();
        
    }

    //vrácení všech buòìk v LiverPart
    public override List<Cell> GetAllCells()
    {
        // seètení všech typù bunìk
        List<Cell> allCell = new List<Cell>();
        allCell.AddRange(hepatotyteCells);
        allCell.AddRange(fatCells);
        allCell.AddRange(damagedHepatotyteCells);
        allCell.AddRange(fibrosisCells);
        allCell.AddRange(cirhosisCells);
        return allCell;

    }
    // vrácení listu buòek dle typu
    public List<Cell> GetCells(Cell.CellType type)
    {
        return GetListByType(type);
    }
    public Part GetPart() { return part; }
    // vrátí poèet všechBunìk 
    public int GetNOfCells()
    {
        return hepatotyteCells.Count + fatCells.Count + damagedHepatotyteCells.Count + fibrosisCells.Count + cirhosisCells.Count;
    }
    // pøeøazení buòky do jiného Listu dle indexu
    public void ChangeCell(Cell.CellType intype, Cell.CellType outtype, int index)
    {
        try
        {
            GetListByType(outtype).Add(GetListByType(intype)[index]);
            GetListByType(intype).RemoveAt(index);
        }
        catch { }
        
    }
    

    // vrácení listu buòek dle typu
    private List<Cell> GetListByType(Cell.CellType type)
    {
        List<Cell> currentList = new List<Cell>();
        switch (type)
        {
            case (Cell.CellType.HEPATOCYTE):
                currentList = hepatotyteCells;
                break;
            case (Cell.CellType.FAT):
                currentList = fatCells;
                break;
            case (Cell.CellType.DAMAGEDHEPATOCYTE):
                currentList = damagedHepatotyteCells;
                break;
            case (Cell.CellType.FIBROSIS):
                currentList = fibrosisCells;
                break;
            case (Cell.CellType.CIRHOSIS):
                currentList = cirhosisCells;
                break;
        }
        return currentList;
    }
    
}
