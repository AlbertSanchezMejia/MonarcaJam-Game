using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Units : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float positionY;
    Camera myCamera;

    void Start()
    {
        myCamera = FindObjectOfType<Camera>();
    }

    private void OnMouseDown()
    {
        SpawnRayPosition();
    }

    void SpawnRayPosition()
    {
        Ray cameraRay = myCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);

        float rayLength;

        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            pointToLook.y = positionY;
            Instantiate(enemyPrefab, pointToLook, Quaternion.identity);
        }
    }

}
