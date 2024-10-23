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
    // vybr�n� n�hodn� bu�ky lalok� dan�ho typu(int[index,Lalok(0left,1right)]
    public static int GetRandomLiverCellByType(LiverCell.CellType cellType)
    {

        // vybr�n� z n�hodn�ho laloku, chceme rad�i prav� lalok(v�ce bu�ek), tak bereme ze 3 ��sel(1-3)  %2
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
        // projit� lalok� a z�sk�n� pom�ru zdrav�ch Bu�ek+po�kozen�ch bu�ek/ostatn�ch bu�ek. po�kozen� bu�ky jsou za 0.5
        //Liver.Get



        // System.Random Random = new System.Random();
    }

    //vr�cen� v�ech bu��k typu hepatocyte
    public static List<LiverCell> GetAllLiverCells()
    {
        // se�ten� v�ech typ� bun�k
        List<LiverCell> allCells = new List<LiverCell>();
        allCells.AddRange(hepatotyteCells);
        allCells.AddRange(fatCells);
        allCells.AddRange(damagedHepatotyteCells);
        allCells.AddRange(fibrosisCells);
        allCells.AddRange(cirhosisCells);
        allCells.AddRange(veinCells);
        return allCells;

    }
    // vr�cen� listu bu�ek dle typu
    public static List<LiverCell> GetCells(LiverCell.CellType type)
    {
        return GetListByType(type);
    }
    // vr�t� po�et v�echBun�k (hepatocyt�)
    public static int GetNOfCells()
    {
        return hepatotyteCells.Count + fatCells.Count + damagedHepatotyteCells.Count + fibrosisCells.Count + cirhosisCells.Count + veinCells.Count;
    }
    // p�e�azen� bu�ky do jin�ho Listu dle indexu
    public static void ChangeCell(LiverCell.CellType intype, LiverCell.CellType outtype, int index)
    {

        GetListByType(outtype).Add(GetListByType(intype)[index]);
        GetListByType(intype).RemoveAt(index);

    }


    // vr�cen� listu bu�ek dle typu
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
