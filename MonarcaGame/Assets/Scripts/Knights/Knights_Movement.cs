using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Knights_Movement : MonoBehaviour
{
    [SerializeField] Animator animator;

    [HideInInspector] public Transform target;
    bool canMove = true;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        canMove = true;
        SetClosestTarget();
    }

    void Update()
    {
        if (target == null && canMove)
        {
            SetClosestTarget();
        }
    }

    void SetClosestTarget()
    {
        target = Knights_Stats.singleton.FindClosestTarget(transform.position);
        if (target == null)
        {
            canMove = false;
            rb.isKinematic = true;
            animator.Play("Idle");
        }
    }

    void FixedUpdate()
    {
        if (target != null)
        {
            Movement();
        }
    }

    void Movement()
    {
        Vector3 targetPosition = new Vector3(target.position.x, transform.position.y, target.position.z);
        transform.LookAt(targetPosition);
        rb.velocity = (transform.forward * Knights_Stats.singleton.movementSpeed * Time.fixedDeltaTime * 10);
    }

}
