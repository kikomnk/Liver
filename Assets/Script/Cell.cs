using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;

public class Cell 
{    
    // mo�nosti v jak�m m��e b�t bu�ka stavu. z�kladn� je Hepatocyte
    public enum CellType {HEPATOCYTE,DAMAGEDHEPATOCYTE,FAT,FIBROSIS,CIRHOSIS }
    private CellType celltype = CellType.HEPATOCYTE;
    //body Bu�ky( reprezentov�na troj�heln�kem)
    private Vector3[] points= new Vector3[2];
    private GameObject triangle;

    private Material material;
    public Cell(Vector3[] points,Material material)
    {
        this.points = points;
        this.material = material;
       
    }
    public Material GetMaterial() { return material; }
    public void SetMaterial(Material material) { this.material = material; }

    public Vector3[] GetPoints() { return points; }
    public GameObject GetTriangle() { return triangle; }
    public void SetTriangle(GameObject triangle) {  this.triangle = triangle; }
    public void SetTriangleMaterial(Material material) 
    { 
        //triangle.     
    }

    // public GameObject GetLiverPart() { return liverPart; }

    public void SetCellType(CellType celltype) { this.celltype = celltype; }
    public CellType GetCellType() { return celltype; }
    public Cell cell() 
    {
        return cell();
        
    }



}
