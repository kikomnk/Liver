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
    // vybr�n� n�hodn� bu�ky lalok� dan�ho typu(int[index,Lalok(0left,1right)]
    public static int[] GetRandomLobeCellIndiciesByType(Cell.CellType cellType)
    {
        int[] indicies = new int[2];
        // vybr�n� z n�hodn�ho laloku, chceme rad�i prav� lalok(v�ce bu�ek), tak bereme ze 3 ��sel(1-3)  %2
        System.Random random = new System.Random();
        int leftRight = random.Next(1, 4) % 2;
        
        // n�hodn� vyberu lalok(0lev�,1prav�)
        int index;
        
        //dle vybran�ho laloku generuji index

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
        // projit� lalok� a z�sk�n� pom�ru zdrav�ch Bu�ek+po�kozen�ch bu�ek/ostatn�ch bu�ek. po�kozen� bu�ky jsou za 0.5
        //Liver.Get


    }


    // public static LiverPart GetLiverPart(LiverPart.Part part) { return liverParts. }


}
