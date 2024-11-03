using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    //Set NavMesh and a target(the player)
    [SerializeField] Transform target;
    NavMeshAgent agent;
    public float enemyDistance = 3.0f;


    private float distance = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, target.transform.position);
        //Engage Distance
        if (distance < enemyDistance)
        {
            //Follow
            agent.SetDestination(target.position);
        }
    }
}
