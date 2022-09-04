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
        textLifes.text = "" + lifes;
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
            textLifes.text = "" + lifes;
        }

        yield return new WaitForEndOfFrame();

        if (lifes == 0 && wasAlreadyCalled == false)
        {
            wasAlreadyCalled = true;
            FindObjectOfType<GameManager>().TowersManager();
            textLifes.text = "";
            Destroy(gameObject);
        }
    }

}
