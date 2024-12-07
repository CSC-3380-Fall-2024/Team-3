using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : Character
{
    private Animator animator;
    private int score;
    private Player player;
    public int scoreValue = 20;


    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        score = player.score;
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        
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
        if(player != null)
        {
            player.AddScore(scoreValue);
        }
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        Destroy(gameObject);
    }
}
