using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlls : MonoBehaviour
{
    GutPoint gutPoint = new GutPoint();
    private KeyCode drinkBeerKey = KeyCode.Keypad1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(drinkBeerKey))
            gutPoint.DrinkBeer();
        
    }
}