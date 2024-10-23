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
            displayText.text = "Játra: " + "\n  ";
            displayText.text += "Dny: " + Liver.GetAge() + " \n  ";
            displayText.text += "Okyslyèení: " + Liver.GetOxygen().ToString() + "\n  ";
            displayText.text += "Poèet hepatocytù: " + Liver.GetCells(LiverCell.CellType.HEPATOCYTE).Count + "\n  ";
            displayText.text += "Poèet ztuènìných bunìk: " + Liver.GetCells(LiverCell.CellType.FAT).Count + "\n  ";
            displayText.text += "Poèet poškozených buòek: " + Liver.GetCells(LiverCell.CellType.DAMAGEDHEPATOCYTE).Count  + "\n  ";
            displayText.text += "Poèet buòìk fibrózy: " + Liver.GetCells(LiverCell.CellType.FIBROSIS).Count + "\n  ";
            displayText.text += "Poèet bunìk cirhózy: " + Liver.GetCells(LiverCell.CellType.CIRHOSIS).Count  + "\n  ";
        }
    }

}
