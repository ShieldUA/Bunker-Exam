using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R_PatrolState : R_BaseState
{
    // Track which waypoint we are currently targeting.
    public int waypointIndex;
    public float waitTimer;

    public override void Enter()
    {
    }

    public override void Perform()
    {
        PatrolCycle();
    }

    public override void Exit()
    {
    }

    public void PatrolCycle()
    {
        // Implement our patrol logic.
        if (enemy.Agent.remainingDistance < 0.2f)
        {
            waitTimer += Time.deltaTime;
            if (waypointIndex < enemy.path.waypoints.Count - 1)
                waypointIndex++;
            else
                waypointIndex = 0;
            enemy.Agent.SetDestination(enemy.path.waypoints[waypointIndex].position);
            waitTimer = 0;
        }
    }

}
