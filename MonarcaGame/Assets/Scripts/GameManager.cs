using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject textWin;
    [SerializeField] GameObject witches;
    [SerializeField] AudioSource musicWin;
    [SerializeField] AudioSource musicGame;
    [HideInInspector] public int towerCount;

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
            witches.SetActive(false);
            musicWin.Play();
            musicGame.Stop();
            textWin.SetActive(true);
        }
    }

}
