using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_ShowRange : MonoBehaviour
{
    MeshRenderer sphereRange;

    private void Start()
    {
        sphereRange = GetComponent<MeshRenderer>();
    }

    private void OnMouseEnter()
    {
        sphereRange.enabled = true;
    }

    private void OnMouseExit()
    {
        sphereRange.enabled = false;
    }
}
