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
    public Animator animator;

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
            agent.SetDestination(target.position); // Follow the player

            int direction = GetDirection();
            animator.SetInteger("Direction", direction); // Sets enemy facing direction for anims

            if (distance <= enemyDistance) // Check if the enemy is close enough
            {
                damageTimer += Time.deltaTime; // Increment the damage timer

                if (damageTimer >= damageInterval) // If enough time has passed = damage
                {
                    animator.SetBool("IsAttacking", true); //Trigger attack anim
                    target.GetComponent<Player>().TakeDamage(3);
                    damageTimer = 0f; //Reset the timer
                }
            }
            else
            {
                animator.SetBool("IsAttacking", false);
            }
        }
        else
        {
            animator.SetBool("IsAttacking", false );
            damageTimer = 0f; //Reset the timer if the enemy is no longer in range
        }
    }

    int GetDirection()
    {
        Vector2 direction = (target.position - transform.position).normalized;

        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            return direction.x > 0 ? 2 : 3; // 2 = East, 3 = West
        }
        else
        {
            return direction.y > 0 ? 0 : 1; // 0 = North, 1 = South
        }
    }
}


