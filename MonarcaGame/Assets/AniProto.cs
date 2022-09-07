using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniProto : MonoBehaviour
{
    [SerializeField] Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            animator.Play("ArmatureAction_001");
        }
    }

}
