using System;
using Unity.VisualScripting;
using UnityEngine;

public class BloodCell
{
    int oxygen = 15;
    int alcohol = 0;
    GameObject sphere;
    Rigidbody rb;
    Vector3 velocity;
    int bounces;
    

    private void Start()
    {

    }

    private void Update()
    {
        velocity = rb.velocity;
    }

    public BloodCell(Vector3 position, int alcohol)
    {
        sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = position;
        

        sphere.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);


         // nastavení náhodého vektoru pro pohyb
         System.Random random = new System.Random();
         float xmove = ((float)random.Next(-100, 101))/100;
         float zmove = ((float)random.Next(-100, 101))/100;


        rb = sphere.AddComponent<Rigidbody>(); // Adds a Rigidbody component to the sphere
        rb.AddForce(new Vector3(xmove, 4f, zmove), ForceMode.VelocityChange);
        rb.useGravity = false;
        var collider = sphere.GetComponent<Collider>();
        collider.isTrigger = true;
        //rb.AddForce(new Vector3(0, 2f, 0), ForceMode.VelocityChange);
        var renderer = sphere.GetComponent<Renderer>();
        renderer.material = Resources.Load("Materials/Blood") as Material;
        

    }
    private void OnCollisionEnter(Collision collision)
    {
           
        
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Vein"))
        {
            float speed = velocity.magnitude;
            Vector3 direction = (sphere.transform.position - collider.transform.position).normalized;
            rb.velocity = direction * speed;
            // poté prohodit if else
            if (collider.gameObject.CompareTag("Cell")) { TransferProperties(); }
            else if (collider.gameObject.CompareTag("Vein")) { }
        }
        bounces++;
        if (bounces == 5)
        { 
            //!!!!!! upravit pro pøemístìní v žilách
            sphere.transform.position = Vector3.zero;
        }
    }
    
    private void TransferProperties()
    {
        Liver.AddOxygen(oxygen / 100);

        if (oxygen <= 0 && alcohol <= 0)
        {
            //sphere.gameObject.IsDestroyed();
        }

    }
}
