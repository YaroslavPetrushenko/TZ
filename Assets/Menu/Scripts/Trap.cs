using System;
using UnityEngine;

public class Trap : MonoBehaviour
{
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnCollisionEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
