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
            displayText.text = "Játra: " + "\n  ";
            displayText.text += "Okyslyèení: " + Liver.GetOxygen().ToString() + "\n  ";
            displayText.text += "Poèet hepatocytù: " + (Liver.LeftLobe.GetCells(Cell.CellType.HEPATOCYTE).Count + Liver.RightLobe.GetCells(Cell.CellType.HEPATOCYTE).Count) + "\n  ";
            displayText.text += "Poèet ztuènìných bunìk: " + (Liver.LeftLobe.GetCells(Cell.CellType.FAT).Count + Liver.RightLobe.GetCells(Cell.CellType.FAT).Count) + "\n  ";
            displayText.text += "Poèet poškozených buòek: " + (Liver.LeftLobe.GetCells(Cell.CellType.DAMAGEDHEPATOCYTE).Count + Liver.RightLobe.GetCells(Cell.CellType.DAMAGEDHEPATOCYTE).Count) + "\n  ";
            displayText.text += "Poèet buòìk fibrózy: " + (Liver.LeftLobe.GetCells(Cell.CellType.FIBROSIS).Count + Liver.RightLobe.GetCells(Cell.CellType.FIBROSIS).Count) + "\n  ";
            displayText.text += "Poèet bunìk cirhózy: " + (Liver.LeftLobe.GetCells(Cell.CellType.CIRHOSIS).Count + Liver.RightLobe.GetCells(Cell.CellType.CIRHOSIS).Count) + "\n  ";
        }
    }

}
