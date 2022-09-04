using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Units : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float positionY;
    [SerializeField] float waitTime;
    Camera myCamera;
    bool unitsCanBePlaced;

    void Start()
    {
        unitsCanBePlaced = true;
        myCamera = FindObjectOfType<Camera>();
    }

    private void OnMouseDown()
    {
        if (unitsCanBePlaced)
        {
            SpawnRayPosition();
        }
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
            unitsCanBePlaced = false;
            Invoke(nameof(PlacedTrue), waitTime);
        }
    }

    void PlacedTrue()
    {
        unitsCanBePlaced = true;
    }

}
