using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword_Bullet : MonoBehaviour
{
    public static Rigidbody swordPrefab;
    [SerializeField] Rigidbody sword;

    private void Awake()
    {
        swordPrefab = sword;
    }

}
