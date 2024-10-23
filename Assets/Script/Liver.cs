using System.Collections.Generic;
using UnityEngine;

public static class Liver
{
    // vlastnosti Jater v procentech
    private static float oxygen = 100f;
    // propustnost dle zdravosti jater
    private static int transmisionRatio;


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

        // vybrání z náhodného laloku, chceme radši pravý lalok(více buòek), tak bereme ze 3 èísel(1-3)  %2
        System.Random random = new System.Random();


        int index;
        index = random.Next(0, GetCells(cellType).Count);

        Debug.Log(GetCells(LiverCell.CellType.HEPATOCYTE).Count);
        return index;
    }

    public static void AddOxygen(float inOxygen) { oxygen += inOxygen; }
    public static void UseOxygen() { oxygen = oxygen - 0.01f; }
    public static float GetOxygen() { return Liver.oxygen; }
    public static void Repair()
    {
        int index = GetRandomLiverCellByType(LiverCell.CellType.DAMAGEDHEPATOCYTE);

    }
    public static void SetTransmisionRatio()
    {
        // projití lalokù a získání pomìru zdravých Buòek+poškozených buòek/ostatních buòek. poškozené buòky jsou za 0.5
        //Liver.Get



        // System.Random Random = new System.Random();
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
