using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Life : MonoBehaviour
{
    [SerializeField] int lifes;

    void RestLifes()
    {
        lifes--;
        if(lifes <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sword"))
        {
            RestLifes();
        }
    }

}
