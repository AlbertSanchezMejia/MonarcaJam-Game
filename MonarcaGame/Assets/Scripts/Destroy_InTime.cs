using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_InTime : MonoBehaviour
{
    [SerializeField] float waitTime;

    void Start()
    {
        Destroy(gameObject, waitTime);
    }

}
