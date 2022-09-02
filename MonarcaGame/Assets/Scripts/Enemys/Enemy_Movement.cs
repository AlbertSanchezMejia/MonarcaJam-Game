using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody rb;
    public Transform target;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
