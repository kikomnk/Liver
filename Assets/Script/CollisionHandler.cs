using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public delegate void CollisionEvent(Collision collision);
    public event CollisionEvent OnCollisionDetected;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Vein") || collision.gameObject.CompareTag("Cell"))
        {
            OnCollisionDetected?.Invoke(collision);
        }
        
    }

}
