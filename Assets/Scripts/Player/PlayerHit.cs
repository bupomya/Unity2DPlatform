using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : Health
{
    public bool isHit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyAttack"))
        {
            if (hp > 0)
            {
                isHit = true;
                PlayerIsHit((int)collision.gameObject.GetComponentInParent<EnemyAttack>().damage);
            }
            else
            {
                Die();
            }
        }
    }

    void PlayerIsHit(int damage)
    {
        if (isHit)
        {
            SetHp(damage);
            StartCoroutine(IsKnockBack());
            animator.SetTrigger("Hit");
            
        }
    }

    IEnumerator IsKnockBack()
    {
        KnockBack();
        yield return new WaitForSeconds(1f);
        isHit = false;
    }

    private void KnockBack()
    {
        //넉백 기능 구현
    }

    protected override void Die()
    {
        animator.SetTrigger("Die");
        //게임 다시 시작 UI
    }
}
