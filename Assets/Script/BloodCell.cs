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
        coll.isTrigger = false;

    }

    private void Start()
    {
        System.Random random = new System.Random();
        float xmove = ((float)random.Next(-100, 101)) / 100;
        float zmove = ((float)random.Next(-100, 101)) / 100;

        rb.AddForce(new Vector3(xmove, 4f, zmove), ForceMode.VelocityChange);
        rb.useGravity = false;

    }

    private void Update()
    {
       //velocity = rb.velocity;
    }

    public void SetPosition(Vector3 position)
    {
        this.transform.position = position;
    }

    public void SetAlcohol(int alc)
    {

    }
    
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Vein"))
        {
            {
                ContactPoint contact = collision.contacts[0];
                Vector3 normal = contact.normal;
                Vector3 dopadovyVektor = -collision.relativeVelocity;

                if (Vector3.Dot(normal, dopadovyVektor) <  0)
                {
                    normal = -normal;
                }

                Vector3 odrazenyVektor = Vector3.Reflect(dopadovyVektor, normal);

                rb.velocity = odrazenyVektor;
            }
        }

        bounces++;
        if (bounces == 5)
        {
            //!!!!!! upravit pro pøemístìní v žilách
            // this.transform.position = Vector3.zero;
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
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
