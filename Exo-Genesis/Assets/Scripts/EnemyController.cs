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

    //Animator
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Calculate distance between enemy and target
        distance = Vector2.Distance(transform.position, target.transform.position);
        
        if (distance < enemyDistance)
        {
            //Follow
            agent.SetDestination(target.position);
            UpdateMovementAnimation(agent.velocity);
        }
        else
        {
            //Stop moving
            agent.ResetPath();
            UpdateMovementAnimation(Vector3.zero);
        }
    }

    private void UpdateMovementAnimation(Vector3 velocity)
    {
        if (animator == null) return;

        // Determine if moving
        bool isMoving = velocity.magnitude > 0.1f;
        animator.SetBool("IsMoving", isMoving);

        if (isMoving)
        {
            // Normalize velocity to get direction
            Vector3 direction = velocity.normalized;

            // Pass direction to Animator
            animator.SetFloat("MoveX", direction.x);
            animator.SetFloat("MoveY", direction.y);
        }
        else
        {
            // Reset direction when idle
            animator.SetFloat("MoveX", 0f);
            animator.SetFloat("MoveY", 0f);
        }
    }
}
