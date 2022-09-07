using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower_Life : MonoBehaviour
{
    [SerializeField] int lifes;
    bool wasAlreadyCalled = false;

    public void RestLife()
    {
        StartCoroutine(Co_RestLifes());
    }

    IEnumerator Co_RestLifes()
    {
        if(lifes > 0)
        {
            lifes--;
        }

        yield return new WaitForEndOfFrame();

        if (lifes == 0 && wasAlreadyCalled == false)
        {
            wasAlreadyCalled = true;
            FindObjectOfType<GameManager>().TowersManager();
            Destroy(gameObject);
        }
    }


}
