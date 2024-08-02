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
    // vybr�n� n�hodn� bu�ky lalok� dan�ho typu(int[index,Lalok(0left,1right)]
    public static int[] GetRandomLobeCellIndiciesByType(Cell.CellType cellType)
    {
        int[] indicies = new int[2];
        // vybr�n� z n�hodn�ho laloku
        System.Random random = new System.Random();
        int ileftRight = random.Next(0, 2);
        bool leftRight = Convert.ToBoolean(ileftRight);
        // n�hodn� vyberu lalok(0lev�,1prav�)
        int index = 0;
        
        //dle vybran�ho laloku generuji index

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
        // projit� lalok� a z�sk�n� pom�ru zdrav�ch Bu�ek+po�kozen�ch bu�ek/ostatn�ch bu�ek. po�kozen� bu�ky jsou za 0.5
        // lobes.GetNOfCells();


    }


    // public static LiverPart GetLiverPart(LiverPart.Part part) { return liverParts. }


}
