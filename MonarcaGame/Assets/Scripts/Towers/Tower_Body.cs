using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Body : MonoBehaviour
{
    Tower_Life tower_Life;

    void Start()
    {
        tower_Life = transform.parent.gameObject.GetComponent<Tower_Life>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sword"))
        {
            tower_Life.RestLife();
        }
    }

}
