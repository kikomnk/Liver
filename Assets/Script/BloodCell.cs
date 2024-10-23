using UnityEngine;

public class BloodCell : MonoBehaviour
{
    int oxygen = 15;
    int alcohol = 0;
    Rigidbody rb;
    Vector3 velocity;
    int bounces;
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        var coll = GetComponent<Collider>();
        coll.isTrigger = true;

    }

    private void Start()
    {
        System.Random random = new System.Random();
        float xmove = ((float)random.Next(-100, 101)) / 100;
        float zmove = ((float)random.Next(-100, 101)) / 100;

        rb.AddForce(new Vector3(xmove, 4f, zmove), ForceMode.VelocityChange);
        rb.useGravity = false;

        var renderer = this.GetComponent<Renderer>();
        renderer.material = Resources.Load("Materials/Blood") as Material;
    }

    private void Update()
    {
        velocity = rb.velocity;
    }

    public void SetPosition(Vector3 position)
    {
        this.transform.position = position;

        this.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }

    public void SetAlcohol(int alc)
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
           
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Vein"))
        {
            float speed = velocity.magnitude;
            Vector3 direction = (this.transform.position - other.transform.position).normalized;
            rb.velocity = direction * speed;
            // poté prohodit if else
            if (other.gameObject.CompareTag("Cell")) { TransferProperties(); }
            else if (other.gameObject.CompareTag("Vein")) { }
        }
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
