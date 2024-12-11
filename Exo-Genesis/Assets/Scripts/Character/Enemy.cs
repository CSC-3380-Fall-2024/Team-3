using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Character
{
    private Animator animator;
    private int score;
    private GameObject player;
    public int scoreValue = 10;

    void Start()
    {
        player = GameObject.Find("Player1");
        animator = GetComponent<Animator>();
    }

    new public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        //There was an optional hurt anim here but we didn't have time

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Debug.Log("Enemy Died!");

        // Trigger the death animation
        animator.SetTrigger("Die");

        // Disable enemy behavior
        GetComponent<Collider2D>().enabled = false;
        GetComponent<NavMeshAgent>().enabled = false; // If applicable

        // Delay destruction to allow the death animation to play
        StartCoroutine(DestroyAfterAnimation());
    }

    IEnumerator DestroyAfterAnimation()
    {
        // Wait for the animation to finish
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        // Add score to the player
        player.GetComponent<Player>().AddScore(scoreValue);


        // Destroy the enemy GameObject

        GameObject.Find("ItemSpawner").GetComponent<ItemSpawner>().StartCoroutine(GameObject.Find("ItemSpawner").GetComponent<ItemSpawner>().RespawnWhenDestroyed(gameObject));  //respawn item after one is destroyed
        Destroy(gameObject);
    }
}
