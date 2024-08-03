using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayText : MonoBehaviour
{
    public TextMeshProUGUI displayText; // Reference to the TextMeshPro component
    private int someValue; // Example value to display

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
            displayText.text += "Okysly�en�: " + Liver.GetOxygen().ToString() + "\n  ";
            displayText.text += "Po�et hepatocyt�: " + (Liver.LeftLobe.GetCells(Cell.CellType.HEPATOCYTE).Count + Liver.RightLobe.GetCells(Cell.CellType.HEPATOCYTE).Count) + "\n  ";
            displayText.text += "Po�et ztu�n�n�ch bun�k: " + (Liver.LeftLobe.GetCells(Cell.CellType.FAT).Count + Liver.RightLobe.GetCells(Cell.CellType.FAT).Count) + "\n  ";
            displayText.text += "Po�et po�kozen�ch bu�ek: " + (Liver.LeftLobe.GetCells(Cell.CellType.DAMAGEDHEPATOCYTE).Count + Liver.RightLobe.GetCells(Cell.CellType.DAMAGEDHEPATOCYTE).Count) + "\n  ";
            displayText.text += "Po�et bu��k fibr�zy: " + (Liver.LeftLobe.GetCells(Cell.CellType.FIBROSIS).Count + Liver.RightLobe.GetCells(Cell.CellType.FIBROSIS).Count) + "\n  ";
            displayText.text += "Po�et bun�k cirh�zy: " + (Liver.LeftLobe.GetCells(Cell.CellType.CIRHOSIS).Count + Liver.RightLobe.GetCells(Cell.CellType.CIRHOSIS).Count) + "\n  ";
        }
    }

}
