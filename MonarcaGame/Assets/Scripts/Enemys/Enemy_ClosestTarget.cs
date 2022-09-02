using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_ClosestTarget : MonoBehaviour
{
    public Transform FindClosestTarget()
    {
        float minDistance = Mathf.Infinity;
        GameObject closestTarget = null;
        GameObject[] allTargets = GameObject.FindGameObjectsWithTag("Tower");

        if (allTargets.Length > 0)
        {
            foreach (GameObject listTarget in allTargets)
            {
                float thisDistance = (listTarget.transform.position - transform.position).sqrMagnitude;
                if (thisDistance < minDistance)
                {
                    minDistance = thisDistance;
                    closestTarget = listTarget;
                }
            }

            return closestTarget.transform;
        }
        else
        {
            return null;
        }

    }

}
