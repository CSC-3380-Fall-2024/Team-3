using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : Character
{
    private Animator animator;
    private int score;


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
        // animator.SetBool("IsDead", true)
        score++; // ALLEN CHANGE THIS WITH YOUR MENU MAGIC IG
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
}
