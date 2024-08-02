using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class VeinLiverPart : LiverPart
{
    // typ Ë·sti Jater
    public PartType partType = PartType.VEIN;
    //Ë·st Jater
    public enum Part { VENA_CANVA, HEPATIC_PORTAL, PORTAL_VEIN };
    public Part part;
    public List<Cell> veinCells;

    public VeinLiverPart()
    {
        veinCells = new List<Cell>();
    }
    public override List<Cell> GetAllCells()
    {       
        return veinCells;
    }
    public int GetNOfCells()
    {
        return veinCells.Count;
    }


}
