using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Body : MonoBehaviour
{
    Tower_Life tower_Life;
    Audio_Manager _audio;

    void Start()
    {
        _audio = FindObjectOfType<Audio_Manager>();
        tower_Life = transform.parent.gameObject.GetComponent<Tower_Life>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sword"))
        {
            _audio.SfxSwords();
            Destroy(other.gameObject);
            tower_Life.RestLife();
        }
    }

}
