using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    //set NavMesh and a target (the player)
    public Transform target;
    private NavMeshAgent agent;
    public float enemyDistance = 3.0f;
    public float damageInterval = 1f; //time between damage application

    private float distance = 0.0f;
    private float damageTimer = 0f; //timer to track when to apply damage

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

        if (distance < enemyDistance)
        {
            agent.SetDestination(target.position); //follow the player

            if (distance <= enemyDistance) // check if the enemy is close enough
            {
                damageTimer += Time.deltaTime; //increment the damage timer

                if (damageTimer >= damageInterval) //if enough time has passed = damage
                {
                    target.GetComponent<Player>().TakeDamage(3);
                    damageTimer = 0f; //reset the timer
                }
            }
        }
        else
        {
            damageTimer = 0f; //reset the timer if the enemy is no longer in range
        }
    }
}


