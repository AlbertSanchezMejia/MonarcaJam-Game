using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Transform[] waypoints;
    int index;

    void Update()
    {
        GoToWaypoint();
        SetNextWaypoint();
    }

    void GoToWaypoint()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoints[index].position, speed * Time.deltaTime);
    }

    void SetNextWaypoint()
    {
        if (Vector3.Distance(transform.position, waypoints[index].position) < 0.1f)
        {
            if (index < waypoints.Length - 1)
            {
                index++;
            }
        }
    }

}
