using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Manager : MonoBehaviour
{
    [SerializeField] AudioSource audioSClips;
    [SerializeField] AudioClip[] sfxDamage;
    //[SerializeField] Audio_Manager _audio;

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
