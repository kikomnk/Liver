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

        this.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }

    public void SetAlcohol(int alc)
    {

    }
    
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Vein"))
        {
            {
                // Získání kontaktního bodu
                ContactPoint contact = collision.contacts[0];

                // Získání normály povrchu
                Vector3 normal = contact.normal;

                // Získání dopadového vektoru (inverzní smìr rychlosti objektu)
                Vector3 dopadovyVektor = -collision.relativeVelocity.normalized;
               // Vector3 dopadovyVektor = -rb.velocity;

                // Zkontroluj orientaci normály pomocí skalárního souèinu
                if (Vector3.Dot(normal, dopadovyVektor) <  0)
                {
                    // Normála je špatnì orientovaná, otoè ji
                    normal = -normal;
                }

                // Nyní máš vždy správnì orientovanou normálu
                Vector3 odrazenyVektor = new Vector3(0, 0, 0);// Vector3.Reflect(dopadovyVektor, normal);

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
