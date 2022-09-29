using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower_Life : MonoBehaviour
{
    [SerializeField] int lifes;
    bool wasAlreadyCalled = false;
    [SerializeField] AudioSource audiosource;
    [SerializeField] GameManager managerGame;

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
            DestroyTower();
        }
    }

    void DestroyTower()
    {
        audiosource.Play();
        Shake_Object.shake.StartShake();

        wasAlreadyCalled = true;
        managerGame.CheckTowerNumber();
        Destroy(gameObject);
    }

}
