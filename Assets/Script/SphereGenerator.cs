using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereGenerator : MonoBehaviour
{
    [field: SerializeField] public GameObject ObjectToSpawn { get; set; }
 
    [field: SerializeField] public Material Material { get; set; }



    private int cells;

    // Start is called before the first frame update
    void Start()
    {

            GameObject obj;
            obj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            /*
            for (int i = 0; i < Liver.GetNOfCells(); i++)
            {

       
               // CreateSphere(Liver.cells[i].GetPosition(), obj, Liver.cells[i].GetLiverPart());
            }
           // CreateSphere(new Vector3(1, 1, 1), obj,);
            */
            Destroy(obj);
        Debug.Log("Vykreslené sféry: "+cells.ToString());


    }
    // Update is called once per frame
    void Update()
    {
        
    }
    // Bump mapping
    void CreateSphere(Vector3 center, GameObject obj,GameObject liverPart)
    {
        Vector3 vsphereSize = new Vector3(4, 4, 4);


        GameObject sphere = new GameObject("Sphere");

        sphere.transform.SetParent(transform);
        sphere.transform.position = center;
        sphere.transform.localScale = vsphereSize;


        Mesh mesh = new Mesh();
        mesh = Instantiate(obj.GetComponent<MeshFilter>().mesh);
        //vypnutí mesh colliderù pro snadnìjší výpoèet
       // MeshCollider collider = sphere.GetComponent<MeshCollider>();
        //collider.sharedMesh = null;

        MeshFilter meshFilter = sphere.AddComponent<MeshFilter>();
        meshFilter.mesh = mesh;


        MeshRenderer sphereRenderer = sphere.AddComponent<MeshRenderer>();
        sphereRenderer.material = Material;

        sphere.AddComponent<MeshCollider>();

        sphereRenderer.enabled = false;

        cells++;

    }

}