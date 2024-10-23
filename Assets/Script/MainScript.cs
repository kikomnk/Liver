using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScript : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("TimePasses", 1f, 1f);

    }

    // Update is called once per frame
    void Update()
    {

        
    }
    void TimePasses() 
    {
        Liver.age();
        Liver.UseOxygen();
    }
}
