using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base_Health : MonoBehaviour
{
    [SerializeField] int health;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            health--;
            Destroy(other.gameObject);
        }
    }

}
