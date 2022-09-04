using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject winText;
    public int towerCount;

    void Start()
    {
        GameObject[] towers = GameObject.FindGameObjectsWithTag("Tower");
        towerCount = towers.Length;
    }

    public void TowersManager()
    {
        towerCount--;
        if(towerCount <= 0)
        {
            winText.SetActive(true);
        }
    }

}
