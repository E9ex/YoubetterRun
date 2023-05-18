using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointController : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWayPointIndex = 0;
    [SerializeField] private float speed = 3f;

    void Update()
    {
        if (Vector3.Distance(waypoints[currentWayPointIndex].transform.position, transform.position) < .1f)
        {
            currentWayPointIndex++;
            if (currentWayPointIndex >= waypoints.Length) 
            {
                currentWayPointIndex = 0; 
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWayPointIndex].transform.position,
            Time.deltaTime * speed); 
    }
}
