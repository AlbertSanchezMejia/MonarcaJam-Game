using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    [SerializeField] float speed;
    public Transform[] waypoint;
    int index;

    void Update()
    {
        if (waypoint.Length > 0)
        {
            GoToWaypoint();
            SetNextWaypoint();
        }
    }

    void GoToWaypoint()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoint[index].position, speed * Time.deltaTime);
    }

    void SetNextWaypoint()
    {
        if (Vector3.Distance(transform.position, waypoint[index].position) < 0.1f)
        {
            if (index < waypoint.Length - 1)
            {
                index++;
            }
        }
    }

}
