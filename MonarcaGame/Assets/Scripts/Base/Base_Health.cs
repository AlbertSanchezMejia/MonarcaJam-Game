using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Base_Health : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] Text textHealth;

    private void Start()
    {
        ShowHealth();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            health--;
            Destroy(other.gameObject);
            ShowHealth();
        }
    }

    void ShowHealth()
    {
        textHealth.text = "Vida: " + health;
    }

}
