using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TestScriptForSphereUp : MonoBehaviour
{
    [field: SerializeField] GameObject sphere;
    // hodnoty krve(kysl�k,alkohol)
    private float oxygen, alcohol;
    // vektor sm�r a ocecn� sm�r( gravitace/sm�r tlaku krve)
    private Vector3 velocity, flowForce;
    public Rigidbody rb;
    CellTriangle CellTriangle;


    void Start()
    {
        oxygen = 0.01f;
        alcohol = 0f;

        rb.AddForce(new Vector3(0, 2f, 0), ForceMode.VelocityChange);


    }

    // Update is called once per frame
    void Update()
    {
        velocity = rb.velocity;
       

    }

    private void OnCollisionEnter(Collision collision)
    {
        float speed = velocity.magnitude;
        Vector3 direction = Vector3.Reflect(velocity.normalized, collision.contacts[0].normal);
        rb.velocity = direction * speed;
        // pot� prohodit if else
        if (collision.gameObject.CompareTag("Cell")) { TransferProperties(); }
        else if (collision.gameObject.CompareTag("Vein")) { }








        // pokud ji� nem� co p�edat, objekt se zni��
     







    }
    private void TransferProperties()
    {
        Liver.AddOxygen(oxygen/100);
        
        if (oxygen <= 0 && alcohol <= 0)
        {
            Destroy(sphere);
        }

    }
}
