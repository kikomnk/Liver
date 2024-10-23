using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayText : MonoBehaviour
{
    public TextMeshProUGUI displayText; // Reference to the TextMeshPro component
    private int someValue=0; // Example value to display

    void Start()
    {
        
        UpdateText(); // Update the text initially
    }

    void Update()
    {


        // Update the text in every frame
        UpdateText();
    }

    void UpdateText()
    {
        if (displayText != null)
        {
            displayText.text = "J�tra: " + "\n  ";
            displayText.text += "Dny: " + Liver.GetAge() + " \n  ";
            displayText.text += "Okysly�en�: " + Liver.GetOxygen().ToString() + "\n  ";
            displayText.text += "Po�et hepatocyt�: " + Liver.GetCells(LiverCell.CellType.HEPATOCYTE).Count + "\n  ";
            displayText.text += "Po�et ztu�n�n�ch bun�k: " + Liver.GetCells(LiverCell.CellType.FAT).Count + "\n  ";
            displayText.text += "Po�et po�kozen�ch bu�ek: " + Liver.GetCells(LiverCell.CellType.DAMAGEDHEPATOCYTE).Count  + "\n  ";
            displayText.text += "Po�et bu��k fibr�zy: " + Liver.GetCells(LiverCell.CellType.FIBROSIS).Count + "\n  ";
            displayText.text += "Po�et bun�k cirh�zy: " + Liver.GetCells(LiverCell.CellType.CIRHOSIS).Count  + "\n  ";
        }
    }

}
