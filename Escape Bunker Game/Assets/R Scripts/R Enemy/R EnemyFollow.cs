using UnityEngine;
using UnityEngine.AI;

public class R_EnemyFollow : MonoBehaviour
{
    public Transform player; // Гравець, за яким бігти
    private NavMeshAgent agent;
    public R_Enemy enemy;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        if (player == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
                player = playerObj.transform;
        }
    }

    void Update()
    {
        if (enemy.CanSeePlayer())
        {
            if (player != null)
            {
                agent.SetDestination(player.position);
            }
        }
    }
}

