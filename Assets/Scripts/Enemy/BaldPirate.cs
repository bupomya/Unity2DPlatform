using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaldPirate : EnemyAttack
{

    

    private void Awake()
    {
        base.Awake();
    }

    
    void Update()
    {

    }

    protected override void Attack()
    {


        animator.SetTrigger("Attack");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Bomb"))
        {
            Attack();    
        }
    }
}
