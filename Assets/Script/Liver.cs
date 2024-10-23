using System.Collections.Generic;
using UnityEngine;

public static class Liver
{
    // vlastnosti Jater v procentech
    private static int old = 0;
    private static float oxygen = 100f;
    private static float alcohol = 100f;
    private static float health = 100f;
    // propustnost dle zdravosti jater
    private static float transmisionRatio = 1f;


    public static List<LiverCell> hepatotyteCells = new List<LiverCell>();
    public static List<LiverCell> fatCells = new List<LiverCell>();
    public static List<LiverCell> damagedHepatotyteCells = new List<LiverCell>();
    public static List<LiverCell> fibrosisCells = new List<LiverCell>();
    public static List<LiverCell> cirhosisCells = new List<LiverCell>();
    public static List<LiverCell> veinCells = new List<LiverCell>();



    static void UpdateLiver()
    {

    }
    // vybrání náhodné buòky lalokù daného typu(int[index,Lalok(0left,1right)]
    public static int GetRandomLiverCellByType(LiverCell.CellType cellType)
    {

        System.Random random = new System.Random();


        int index;
        index = random.Next(0, GetCells(cellType).Count);

        Debug.Log(GetCells(LiverCell.CellType.HEPATOCYTE).Count);
        return index;
    }
    // methods for age
    public static void age() { old++; }
    public static string GetAge() { return old.ToString(); }
    //methods for oxygen
    public static void AddOxygen(float inOxygen) { oxygen += inOxygen; }
    public static void UseOxygen() { oxygen = oxygen - 0.01f; }
    public static float GetOxygen() { return Liver.oxygen; }
    // methods for alcohol
    public static void Repair()
    {
        int index = GetRandomLiverCellByType(LiverCell.CellType.DAMAGEDHEPATOCYTE);

    }
    public static void setHealth() 
    {
        health = 100f * (hepatotyteCells.Count + (damagedHepatotyteCells.Count / 2)) / (GetNOfCells() - veinCells.Count);
    }
    public static void SetTransmisionRatio()
    {
        transmisionRatio = health / 100f;
          
    }

    //vrácení všech buòìk typu hepatocyte
    public static List<LiverCell> GetAllLiverCells()
    {
        // seètení všech typù bunìk
        List<LiverCell> allCells = new List<LiverCell>();
        allCells.AddRange(hepatotyteCells);
        allCells.AddRange(fatCells);
        allCells.AddRange(damagedHepatotyteCells);
        allCells.AddRange(fibrosisCells);
        allCells.AddRange(cirhosisCells);
        allCells.AddRange(veinCells);
        return allCells;

    }
    // vrácení listu buòek dle typu
    public static List<LiverCell> GetCells(LiverCell.CellType type)
    {
        return GetListByType(type);
    }
    // vrátí poèet všechBunìk (hepatocytù)
    public static int GetNOfCells()
    {
        return hepatotyteCells.Count + fatCells.Count + damagedHepatotyteCells.Count + fibrosisCells.Count + cirhosisCells.Count + veinCells.Count;
    }
    // pøeøazení buòky do jiného Listu dle indexu
    public static void ChangeCell(LiverCell.CellType intype, LiverCell.CellType outtype, int index)
    {

        GetListByType(outtype).Add(GetListByType(intype)[index]);
        GetListByType(intype).RemoveAt(index);

    }


    // vrácení listu buòek dle typu
    private static List<LiverCell> GetListByType(LiverCell.CellType type)
    {
        List<LiverCell> currentList = new List<LiverCell>();
        switch (type)
        {
            case (LiverCell.CellType.HEPATOCYTE):
                currentList = hepatotyteCells;
                break;
            case (LiverCell.CellType.FAT):
                currentList = fatCells;
                break;
            case (LiverCell.CellType.DAMAGEDHEPATOCYTE):
                currentList = damagedHepatotyteCells;
                break;
            case (LiverCell.CellType.FIBROSIS):
                currentList = fibrosisCells;
                break;
            case (LiverCell.CellType.CIRHOSIS):
                currentList = cirhosisCells;
                break;
            case (LiverCell.CellType.VEIN):
                currentList = veinCells;
                break;
        }
        return currentList;
    }


    // public static LiverPart GetLiverPart(LiverPart.Part part) { return liverParts. }


}
