using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaldPirate : EnemyAttack
{
    
    private void Awake()
    {
        base.Awake();
    }

    protected override void Attack()
    {
        // 데미지만큼 player HP 깎음

        animator.SetTrigger("Attack");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // hit animation

            Attack();

        }else if (collision.CompareTag("Bomb"))
        {
            // BaldPirate 공격방향으로 날아감
            Attack();
        }

    }
}
