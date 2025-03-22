using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class R_Enemy : MonoBehaviour
{
    private R_StateMachine stateMachine;
    private NavMeshAgent agent;
    private GameObject player;
    public Transform r_player;
    public GameObject Hand1;
    public GameObject Hand2;
    public GameObject Rifle;

    public NavMeshAgent Agent { get => agent; }

    public R_Path path;
    [Header("Sight Values")]
    public float sightDistance = 20f;
    public float fieldOfView = 85f;
    public float eyeHeight;
    [Header("Weapon Values")]
    public Transform gunBarrel;
    [Range(0.1f, 10f)]
    public float fireRate;
    // Just for debugging purposes.
    [SerializeField]
    private string currentState;

    // Start is called before the first frame update
    void Start()
    {
        stateMachine = GetComponent<R_StateMachine>();
        agent = GetComponent<NavMeshAgent>();
        stateMachine.Initialise();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        CanSeePlayer();
    }

    public bool CanSeePlayer()
    {
        if (player != null)
        {
            //is the player close enough to be seen?
            if (Vector3.Distance(transform.position, player.transform.position) < sightDistance)
            {
                Vector3 targetDirection = player.transform.position - transform.position - (Vector3.up * eyeHeight);
                float angleToPlayer = Vector3.Angle(targetDirection, transform.forward);
                if (angleToPlayer >= -fieldOfView && angleToPlayer <= fieldOfView)
                {
                    Ray ray = new Ray(transform.position + (Vector3.up * eyeHeight), targetDirection);
                    RaycastHit hitInfo = new RaycastHit();
                    if (Physics.Raycast(ray, out hitInfo, sightDistance))
                    {
                        if (hitInfo.transform.gameObject == player)
                        {
                            Rifle.SetActive(true);
                            Hand2.SetActive(true);
                            Hand1.SetActive(true);
                            agent.SetDestination(r_player.position);
                            Debug.DrawRay(ray.origin, ray.direction * sightDistance);
                            return true;
                        }
                    }
                }
                else
                {
                    Rifle.SetActive(false);
                    Hand2.SetActive(false);
                    Hand1.SetActive(false);
                }
            }
        }
        return false;
    }
}
