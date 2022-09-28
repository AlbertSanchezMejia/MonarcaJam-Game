using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject textWin;
    [SerializeField] GameObject witches;
    [HideInInspector] public int towerCount;

    [SerializeField] AudioSource musicGame1;
    [SerializeField] AudioSource musicGame2;
    [SerializeField] AudioSource musicWin;

    void Start()
    {
        GameObject[] towers = GameObject.FindGameObjectsWithTag("Tower");
        towerCount = towers.Length;
    }

    public void CheckTowerNumber()
    {
        towerCount--;
        if(towerCount <= 0)
        {
            Destroy(witches);
            textWin.SetActive(true);
            PlayWinMusic();
            return;
        }
        PlayTowerDestroyedMusic();
    }

    void PlayTowerDestroyedMusic()
    {
        if(musicGame2.isPlaying == false && towerCount <= 2)
        {
            musicGame1.Stop();
            musicGame2.Play();
        }
    }

    void PlayWinMusic()
    {
        musicGame1.Stop();
        musicGame2.Stop();
        musicWin.Play();
    }

}
