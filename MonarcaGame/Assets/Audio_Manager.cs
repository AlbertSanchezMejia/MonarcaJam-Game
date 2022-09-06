using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Manager : MonoBehaviour
{
    [SerializeField] AudioSource audiosource;
    [SerializeField] AudioClip[] sfxDamage;

    public void PlaySound(AudioClip clip)
    {
        audiosource.PlayOneShot(clip);
    }

    public void SfxSwords()
    {
        int a = Random.Range(0, sfxDamage.Length);
        audiosource.PlayOneShot(sfxDamage[a]);
    }

}
