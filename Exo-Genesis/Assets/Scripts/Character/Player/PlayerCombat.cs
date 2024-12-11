using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;

    public Transform attackPoint;
    public LayerMask enemyLayers;

    public float attackRange = 0.5f;
    public int attackDamage = 40;


    //Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }

    void Attack()
    {
        //Play attack anim
        animator.SetBool("Attack 0",true);

        //Detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        //Dmg Enemies
        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit" + enemy.name);
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }

        //Reset attack animation
        StartCoroutine(ResetAttackAnimation());

    }

    IEnumerator ResetAttackAnimation()
    {
        yield return new WaitForSeconds(0.1f); //Adjust timing as needed
        animator.SetBool("Attack 0", false);
        animator.speed = 1.0f; //Reset to normal speed
    }
}
