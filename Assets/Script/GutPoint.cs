using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GutPoint : BloodGenerator
{
    [field: SerializeField] GameObject ThisObject;
    BloodCell Bloodcell;



    // Tato t��da uchov�v� vlastnosti krve ze st�ev a generuje ji
    private int alcohol = 0;
    public GutPoint()
    {
        

    }
    void Start()
    {
        InvokeRepeating("GenerateNewCell", 1f, 1f);
    }
    void Update()
    {
        
        
    }
    public void DrinkBeer()
    {
        alcohol += 10;
        Debug.Log(alcohol.ToString());
    }
    void GenerateNewCell () { Bloodcell = new BloodCell(ThisObject.transform.position,alcohol ); }



}
