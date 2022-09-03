using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Life : MonoBehaviour
{
    [SerializeField] int lifes;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sword"))
        {
            StartCoroutine(Co_RestLifes());
        }
    }

    IEnumerator Co_RestLifes()
    {
        lifes--;
        yield return new WaitForEndOfFrame();

        if (lifes <= 0)
        {
            Destroy(transform.parent.gameObject);
        }
    }



}
