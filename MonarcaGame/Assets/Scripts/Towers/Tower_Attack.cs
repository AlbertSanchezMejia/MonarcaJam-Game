using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Attack : MonoBehaviour
{
    [SerializeField] float arrowSpeed;
    [SerializeField] float waitToAttack;
    [SerializeField] Transform sentinel;
    [SerializeField] Rigidbody arrowPrefab;
    [SerializeField] List<GameObject> nearbyUnits;
    bool canAttack;
    [SerializeField] Animator aniAttack;
    Audio_Manager _audio;
    [SerializeField] AudioClip sfxShootMagic;

    void Start()
    {
        _audio = FindObjectOfType<Audio_Manager>();
        TrueCanAttack();
        InvokeRepeating(nameof(CheckTargets), 0, 0.2f);
    }

    void TrueCanAttack()
    {
        canAttack = true;
    }

    void CheckTargets()
    {
        if (nearbyUnits.Count <= 0)
        {
            return;
        }

        if (nearbyUnits[0] == null)
        {
            nearbyUnits.RemoveAt(0);
            CheckTargets();
        }
        else { StartAttack(); }
    }

    void StartAttack()
    {
        if (canAttack)
        {
            sentinel.LookAt(nearbyUnits[0].transform);
            ShootArrow();
            canAttack = false;
            Invoke(nameof(TrueCanAttack), waitToAttack);

            _audio.PlaySound(sfxShootMagic);

            if (aniAttack != null)
            {
                aniAttack.Play("Attack");
            }

        }
    }

    void ShootArrow()
    {
        Rigidbody arrow = Instantiate(arrowPrefab, sentinel.position, sentinel.rotation);
        arrow.velocity = sentinel.forward * arrowSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Unit"))
        {
            nearbyUnits.Add(other.gameObject);
        }
    }

}
