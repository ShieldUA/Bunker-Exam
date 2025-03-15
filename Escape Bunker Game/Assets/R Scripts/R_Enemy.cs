using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class R_Enemy : MonoBehaviour
{
    public GameObject player;
    NavMeshAgent agent;

    [SerializeField] LayerMask groundLayer, playerLayer;

    // Patrol
    Vector3 destPoint;
    bool walkpointSet;
    [SerializeField] float range;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        Patrol();
    }

    void Patrol()
    {
        if (!walkpointSet) SearchForDest();
        if (walkpointSet) agent.SetDestination(destPoint);
        if (Vector3.Distance(transform.position, destPoint) < 10) walkpointSet = false;
    }

    void SearchForDest()
    {
        float z = Random.Range(-range, range);
        float x = Random.Range(-range, range);

        destPoint = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);

        // Перевірка наявності землі за допомогою Raycast:
        if (Physics.Raycast(destPoint, Vector3.down, out RaycastHit hit, 2f, groundLayer))
        {
            walkpointSet = true;
        }
    }
}