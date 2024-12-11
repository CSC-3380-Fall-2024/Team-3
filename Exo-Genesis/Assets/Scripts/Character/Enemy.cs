using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Unity.VisualScripting;
using UnityEngine;

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

        //animator.SetTrigger("Hurt") this will get added

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Debug.Log("Enemy Died!");
        player.GetComponent<Player>().AddScore(scoreValue);
        GameObject.Find("ItemSpawner").GetComponent<ItemSpawner>().StartCoroutine(GameObject.Find("ItemSpawner").GetComponent<ItemSpawner>().RespawnWhenDestroyed(gameObject));  //respawn item after one is destroyed
        Destroy(gameObject);
    }
}
