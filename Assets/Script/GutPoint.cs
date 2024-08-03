using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GutPoint : MonoBehaviour
{
    
    // Tato tøída uchovává vlastnosti krve ze støev a generuje ji
    private float alcohol = 0f;
    public GutPoint()
    {
        
    
    }
    void Start()
    {
            
    }
    void Update()
    {
        
    }
    public void DrinkBeer()
    {
        alcohol += 0.01f;
        Debug.Log(alcohol.ToString());
    }

}
