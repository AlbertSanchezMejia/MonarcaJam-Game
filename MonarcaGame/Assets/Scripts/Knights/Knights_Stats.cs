using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knights_Stats : MonoBehaviour
{
    public static Knights_Stats singleton;

    [Header ("Stats of the Knights")]
    public float movementSpeed;
    public float attackDelay;

    void Awake()
    {
        if(singleton == null)
        {
            singleton = this;
            DontDestroyOnLoad(this);
        }
        else { Destroy(gameObject); }
    }

    public Transform FindClosestTarget(Vector3 knightPosition)
    {
        float minDistance = Mathf.Infinity;
        GameObject closestTarget = null;
        GameObject[] allTargets = GameObject.FindGameObjectsWithTag("Tower");

        if (allTargets.Length > 0)
        {
            foreach (GameObject listTarget in allTargets)
            {
                float thisDistance = (listTarget.transform.position - knightPosition).sqrMagnitude;
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
