using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Towers_Statics : MonoBehaviour
{
    public static Towers_Statics statics;

    public float arrowSpeed;
    public float waitToAttack;

    public AudioSource audioSClips;
    public AudioClip[] sfxDamage;

    void Awake()
    {
        if (statics == null)
        {
            statics = this;
            DontDestroyOnLoad(this);
        }
        else { Destroy(gameObject); }
    }

    public void PlaySound(AudioClip clip)
    {
        audioSClips.PlayOneShot(clip);
    }

    public void SfxSwords()
    {
        int a = Random.Range(0, sfxDamage.Length);
        audioSClips.PlayOneShot(sfxDamage[a]);
    }

}
