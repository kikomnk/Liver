using System.Collections.Generic;

public abstract class LiverPart
{
    public enum PartType { LOBE, VEIN };

    public List<Cell> cells = new();
    public LiverPart()
    {

    }

    public virtual List<Cell> GetAllCells()
    {
        return cells;
    }
    //public string getName() { return name; }


}
