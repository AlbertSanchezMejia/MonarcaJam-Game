using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knights_Collisions : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Arrow"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
