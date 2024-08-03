using System;
using UnityEngine;

public static class Liver
{
    // vlastnosti Jater v procentech
    private static float oxygen = 100f;
    // propustnost dle zdravosti jater
    private static int transmisionRatio;

    public static LobeLiverPart RightLobe, LeftLobe;
    public static VeinLiverPart VenaCanva, HepaticPortal, PortalVein;




    static void UpdateLiver()
    {

    }
    // vybrání náhodné buòky lalokù daného typu(int[index,Lalok(0left,1right)]
    public static int[] GetRandomLobeCellIndiciesByType(Cell.CellType cellType)
    {
        int[] indicies = new int[2];
        // vybrání z náhodného laloku, chceme radši pravý lalok(více buòek), tak bereme ze 3 èísel(1-3)  %2
        System.Random random = new System.Random();
        int leftRight = random.Next(1, 4) % 2;
        
        // náhodnì vyberu lalok(0levý,1pravý)
        int index;
        
        //dle vybraného laloku generuji index

        if (leftRight == 0)
        {

            index = random.Next(0, LeftLobe.GetCells(cellType).Count);
           
        }
        else
        {
            index = random.Next(0, RightLobe.GetCells(cellType).Count);
        }

        indicies[0] = index;
        indicies[1] = leftRight;
        Debug.Log(LeftLobe.GetCells(Cell.CellType.HEPATOCYTE).Count + " + " + RightLobe.GetCells(Cell.CellType.HEPATOCYTE).Count);
        return indicies;
    }
    public static int GetNOfLobesCells()
    {
        int count = RightLobe.GetNOfCells() + LeftLobe.GetNOfCells();
        return count;

    }
    public static void AddOxygen(float inOxygen) { oxygen += inOxygen; }
    public static void UseOxygen() { oxygen = oxygen - 0.001f; }
    public static float GetOxygen() { return Liver.oxygen; }
    public static void SetTransmisionRatio()
    {
        // projití lalokù a získání pomìru zdravých Buòek+poškozených buòek/ostatních buòek. poškozené buòky jsou za 0.5
        //Liver.Get


    }


    // public static LiverPart GetLiverPart(LiverPart.Part part) { return liverParts. }


}
