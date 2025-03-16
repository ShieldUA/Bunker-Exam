using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class R_AITarget : MonoBehaviour
{
    public List<GameObject> waypoints;
    public float speed = 2;
    int index = 0;
    public bool isLoop = true;

    private void Update()
    {
        if (waypoints.Count == 0) return;

        Vector3 destination = waypoints[index].transform.position;
        Vector3 newPos = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
        transform.position = newPos;

        float distance = Vector3.Distance(transform.position, destination);

        if (distance <= 1)
        {
            if (index < waypoints.Count - 1)
            {
                index++;
            }
            else
            {
                if (isLoop)
                {
                    index = 0;
                }
            }
        }
    }
}