using UnityEngine;

public class GutPoint : BloodGenerator
{
    [field: SerializeField] GameObject ThisObject;
    [field: SerializeField] BloodCell prefab;
    BloodCell Bloodcell;



    // Tato tøída uchovává vlastnosti krve ze støev a generuje ji
    private int alcohol = 0;
    public GutPoint()
    {


    }
    void Start()
    {
        InvokeRepeating("GenerateNewCell", 1f, 0.5f);
    }
    void Update()
    {


    }
    public void DrinkBeer()
    {
        alcohol += 10;
        Debug.Log(alcohol.ToString());
    }
    void GenerateNewCell()
    {
        //Bloodcell = new BloodCell(ThisObject.transform.position, alcohol);
        Bloodcell = Instantiate<BloodCell>(prefab, ThisObject.transform.position, Quaternion.identity);
        Bloodcell.SetPosition(this.transform.position);
        Bloodcell.SetAlcohol(alcohol);
    }
}
