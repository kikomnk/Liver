using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.AI;

public class Testsphere : MonoBehaviour
{
   // [field:SerializeField]
    //private SphereCollider Collider { get; set; }
    private Transform position { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        //Collider = GetComponent<SphereCollider>();
        position = GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        //Collider.radius += 0.01f;
        position.position += new Vector3(0, 0, 0.1f);
    }
}
