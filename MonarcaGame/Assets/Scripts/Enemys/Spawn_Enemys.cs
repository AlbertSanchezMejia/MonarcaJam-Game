using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Enemys : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float positionY;
    Camera myCamera;
    public Vector3 algo;
    void Start()
    {
        myCamera = FindObjectOfType<Camera>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //SpawnEnemy();
            SpawnRayPosition();
        }
        algo = myCamera.ScreenToWorldPoint(Input.mousePosition);
    }

    void SpawnEnemy()
    {
        Vector3 spawnPosition = myCamera.ScreenToWorldPoint(Input.mousePosition);
        spawnPosition.y = positionY;
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

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
