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
        // ��������ŭ player HP ����

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
            // BaldPirate ���ݹ������� ���ư�
            Attack();
        }

    }
}
