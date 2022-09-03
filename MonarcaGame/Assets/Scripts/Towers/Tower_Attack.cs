using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Attack : MonoBehaviour
{
    [SerializeField] float arrowSpeed;
    [SerializeField] float attackDelay;
    [SerializeField] Transform sentinel;
    [SerializeField] Rigidbody arrowPrefab;
    [SerializeField] List<GameObject> nearbyUnits;
    bool canAttack;

    void Start()
    {
        TrueCanAttack();
    }

    void TrueCanAttack()
    {
        canAttack = true;
    }

    void Update()
    {
        CheckTargets();
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
        sentinel.LookAt(nearbyUnits[0].transform);
        if (canAttack)
        {
            ShootArrow();
            canAttack = false;
            Invoke(nameof(TrueCanAttack), attackDelay);
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

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Unit"))
        {
            nearbyUnits.Remove(other.gameObject);
        }
    }

}
