using System.Collections.Generic;
using UnityEngine;

public class CellGenerator : MonoBehaviour
{
    [field: SerializeField] public GameObject ObjectToSpawn { get; set; }
    [field: SerializeField] public GameObject Point1 { get; set; }
    [field: SerializeField] public GameObject Point2 { get; set; }
    [field: SerializeField] public List<MeshCollider> Colliders { get; set; }
    private Vector3 spawn;

    // Start is called before the first frame update
    void Start()
    {
        StartGenerate();
    }
    void StartGenerate()
    {
        float minY = Point2.transform.position.y;
        float maxY = Point1.transform.position.y;
        for (float i = 83.5f; i > 4.5f; i -= 0.25f)
        {
            for (float j = 45.5f; j > -28.5f; j -= 0.25f)
            {
                for (float k = 44f; k > -32f; k -= 0.25f)
                {
                    spawn = new Vector3(j, i, k);
                    if (IsColliding(spawn))
                    {
                        Instantiate(ObjectToSpawn, spawn, Quaternion.identity);
                    }
                }
            }
        }
    }
    bool IsColliding(Vector3 vec)
    {
        Collider[] colliders = Physics.OverlapSphere(vec, 0.25f);
        foreach (Collider collider in colliders)
        {
            if (collider != null && collider.gameObject.CompareTag("Liver") && collider is MeshCollider)
            {
                return true;
            }
        }
        return false;
    }
}
