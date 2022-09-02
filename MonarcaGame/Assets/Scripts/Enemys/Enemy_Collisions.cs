using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Collisions : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Tramp"))
        {
            Destroy(gameObject);
        }
    }

}
