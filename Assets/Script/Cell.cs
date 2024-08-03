using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;

public class Cell 
{    
    // možnosti v jakém mùže být buòka stavu. základní je Hepatocyte
    public enum CellType {HEPATOCYTE,FAT, DAMAGEDHEPATOCYTE, FIBROSIS,CIRHOSIS }
    private CellType celltype = CellType.HEPATOCYTE;
    //body Buòky( reprezentována trojúhelníkem)
    private Vector3[] points= new Vector3[2];
    private GameObject triangle;

    public Cell(Vector3[] points)
    {
        this.points = points;
        
       
    }


    public Vector3[] GetPoints() { return points; }
    public GameObject GetTriangle() { return triangle; }
    public void SetTriangle(GameObject triangle) {  this.triangle = triangle; }
    public void SetTriangleMaterial(Material material) 
    {
        var material2 = triangle.GetComponent<Renderer>();   
        material2.material = material;
    }

    // public GameObject GetLiverPart() { return liverPart; }

    public void SetCellType(CellType celltype) { this.celltype = celltype; }
    public CellType GetCellType() { return celltype; }
    public Cell cell() 
    {
        return cell();
        
    }



}
