using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Knights : MonoBehaviour
{
    [SerializeField] GameObject unitPrefab;
    Camera myCamera;

    void Start()
    {
        myCamera = FindObjectOfType<Camera>();
    }

    private void OnMouseDown()
    {
        SpawnOnClickPosition();
    }

    void SpawnOnClickPosition()
    {
        Ray cameraRay = myCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(cameraRay, out RaycastHit hitInfo, Mathf.Infinity))
        {
            Vector3 pointToLook = hitInfo.point;
            pointToLook.y = 0.25f;
            Instantiate(unitPrefab, pointToLook, Quaternion.identity);
        }
    }

}
