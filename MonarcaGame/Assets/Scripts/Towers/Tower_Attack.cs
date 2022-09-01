using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Attack : MonoBehaviour
{
    [SerializeField] float attackDelay;
    void Start()
    {
        InvokeRepeating(nameof(Attack), 1f, attackDelay);
    }

    void Attack()
    {
        GameObject[] enemy = GameObject.FindGameObjectsWithTag("Enemy");
        if(enemy.Length > 0)
        {
            if(enemy[0] != null)
            Destroy(enemy[0]);
        }
    }

}
