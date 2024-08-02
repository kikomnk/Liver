using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class LiverPart
{
    public enum PartType { LOBE, VEIN };
    
    public List<Cell> cells;    
    public LiverPart()
    {

    }

    //public string getName() { return name; }


}
