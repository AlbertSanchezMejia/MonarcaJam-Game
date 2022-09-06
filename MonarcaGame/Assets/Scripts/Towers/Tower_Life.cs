using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower_Life : MonoBehaviour
{
    [SerializeField] int lifes;
    [SerializeField] Text textLifes;
    bool wasAlreadyCalled = false;

    private void Start()
    {
        WriteTextLife("" + lifes);
    }

    public void RestLife()
    {
        StartCoroutine(Co_RestLifes());
    }

    IEnumerator Co_RestLifes()
    {
        if(lifes > 0)
        {
            lifes--;
            WriteTextLife("" + lifes);
        }

        yield return new WaitForEndOfFrame();

        if (lifes == 0 && wasAlreadyCalled == false)
        {
            wasAlreadyCalled = true;
            FindObjectOfType<GameManager>().TowersManager();
            WriteTextLife("");
            Destroy(gameObject);
        }
    }

    void WriteTextLife(string texto)
    {
        //textLifes.text = texto;
    }

}
