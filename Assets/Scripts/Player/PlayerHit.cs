using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : Health
{
    public bool isHit;

    [SerializeField] float knockbackPower;
    [SerializeField] float knockbackDuration;
    [SerializeField] float knockbackCounter;

    private void Update()
    {
        if (isHit && knockbackCounter > 0) 
        {
            knockbackCounter -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyAttack"))
        {
            if (hp > 0)
            {
                isHit = true;
                PlayerIsHit((int)collision.gameObject.GetComponentInParent<EnemyAttack>().damage);

                Vector2 knockbackDir = (transform.position - collision.transform.position).normalized; // 방향 계산

                GetComponent<Rigidbody2D>().AddForce(knockbackDir * knockbackPower, ForceMode2D.Impulse);

                StartCoroutine(IsKnockBack());
            }
            else
            {
                //isHit = true;
                Die();
            }
        }
    }

    void PlayerIsHit(int damage)
    {
        if (isHit)
        {
            SetHp(damage);
            animator.SetTrigger("Hit");
            
        }
    }

    IEnumerator IsKnockBack()
    {

        knockbackCounter = knockbackDuration;

        yield return new WaitForSeconds(1f);

        isHit = false;
    }

    protected override void Die()
    {
        animator.SetTrigger("Die");
        //게임 다시 시작 UI
    }
}
