using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Enemy_ClosestTarget _closestTarget;
    public Transform target;
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
        target = _closestTarget.FindClosestTarget();
        if (target == null)
        {
            canMove = false;
            rb.isKinematic = true;
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
        rb.velocity = (transform.forward * speed * Time.fixedDeltaTime * 10);
    }

}
