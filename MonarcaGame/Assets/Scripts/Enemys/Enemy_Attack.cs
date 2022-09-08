using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Attack : MonoBehaviour
{
    [SerializeField] Enemy_Movement _movement;
    [SerializeField] float attackDelay;
    [SerializeField] bool canAttack;
    Transform currentTarget;
    [SerializeField] Animator animator;

    void ChangeState()
    {
        if(currentTarget != null)
        {
            Attack();
            Invoke(nameof(ChangeState), attackDelay);
        }
        else { canAttack = true; }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_movement.target == null)
        {
            return; }

        if (other.gameObject == _movement.target.gameObject && canAttack == true)
        {
            canAttack = false;
            currentTarget = _movement.target;
            ChangeState();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (_movement.target == null)
        {
            return; }

        if (other.gameObject == _movement.target.gameObject)
        {
            CancelInvoke();
            canAttack = true;
        }
    }

    void Attack()
    {
        Rigidbody sword = Instantiate(ShootB.swordPrefab, transform.position, transform.rotation);
        sword.velocity = transform.forward * 5;

        animator.Play("Attack");
    }

}
