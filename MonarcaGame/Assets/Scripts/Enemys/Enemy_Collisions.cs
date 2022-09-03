using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Collisions : MonoBehaviour
{
    [SerializeField] int life;
    [SerializeField] GameObject aaa;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Arrow"))
        {
            life--;
            Destroy(other.gameObject);
            if (life <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
