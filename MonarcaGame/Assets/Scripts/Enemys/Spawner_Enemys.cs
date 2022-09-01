using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_Enemys : MonoBehaviour
{
    [SerializeField] Enemy_Movement enemy;
    [SerializeField] Transform[] waypoints;

    private void OnMouseDown()
    {
        Enemy_Movement newEnemy;
        newEnemy = Instantiate(enemy, transform.position, transform.rotation);
        newEnemy.waypoint = this.waypoints;
    }

}
