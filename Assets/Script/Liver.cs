using System;
using UnityEngine;

public static class Liver
{
    // vlastnosti Jater v procentech
    private static float oxygen = 100f, alcohol = 0f;
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
        // vybrání z náhodného laloku
        System.Random random = new System.Random();
        int ileftRight = random.Next(0, 2);
        bool leftRight = Convert.ToBoolean(ileftRight);
        // náhodnì vyberu lalok(0levý,1pravý)
        int index = 0;
        
        //dle vybraného laloku generuji index

        if (!leftRight)
        {

            index = random.Next(0, LeftLobe.GetCells(cellType).Count);
           
        }
        else
        {
            index = random.Next(0, RightLobe.GetCells(cellType).Count);
        }

        indicies[0] = index;
        indicies[1] = ileftRight;
        Debug.Log(LeftLobe.GetCells(Cell.CellType.HEPATOCYTE).Count + " + " + RightLobe.GetCells(Cell.CellType.HEPATOCYTE).Count);
        return indicies;
    }
    public static int GetNOfLobesCells()
    {
        int count = RightLobe.GetNOfCells() + LeftLobe.GetNOfCells();
        return count;

    }
    public static void AddOxygen(float oxygen) { Liver.oxygen += oxygen; }
    public static void AddAlcohol(float alcohol) { Liver.alcohol += alcohol; }
    public static void SetTransmisionRatio()
    {
        // projití lalokù a získání pomìru zdravých Buòek+poškozených buòek/ostatních buòek. poškozené buòky jsou za 0.5
        // lobes.GetNOfCells();


    }


    // public static LiverPart GetLiverPart(LiverPart.Part part) { return liverParts. }


}
