using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Attack : MonoBehaviour
{
    [SerializeField] Transform sentinel;
    [SerializeField] Rigidbody arrowPrefab;
    [SerializeField] List<GameObject> nearbyUnits;
    bool canAttack;

    [SerializeField] AudioClip sfxShootMagic;

    void Start()
    {
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
            Invoke(nameof(TrueCanAttack), Towers_Statics.statics.waitToAttack);

            Towers_Statics.statics.PlaySound(sfxShootMagic);
        }
    }

    void ShootArrow()
    {
        Rigidbody arrow = Instantiate(arrowPrefab, sentinel.position, sentinel.rotation);
        arrow.velocity = sentinel.forward * Towers_Statics.statics.arrowSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Unit"))
        {
            nearbyUnits.Add(other.gameObject);
        }
    }

}
