using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy_AI : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Enemy_ClosestTarget _closestTarget;
    [SerializeField] Enemy_Movement _movement;
    bool canMove;

    void Start()
    {
        canMove = true;
        SetClosestTarget();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            canMove = true;
            SetClosestTarget();
        }

        if (_movement.target == null && canMove)
        {
            SetClosestTarget();
        }
    }


    void SetClosestTarget()
    {
        _movement.target = _closestTarget.FindClosestTarget();
        if(_movement.target == null)
        {
            canMove = false;
        }
    }

}
