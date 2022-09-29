using UnityEngine;

public class Towers_Statics : MonoBehaviour
{
    public static Towers_Statics statics;
    void Awake()
    {
        if (statics == null)
        {
            statics = this;
            DontDestroyOnLoad(this);
        }
        else { Destroy(gameObject); }
    }

    public float arrowSpeed;
    public float waitToAttack;

    public AudioSource audioSClips;
    public AudioClip[] sfxDamage;

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
