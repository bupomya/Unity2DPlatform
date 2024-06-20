using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator animator;

    [SerializeField] float bombSpeed;
    [SerializeField] float addSpeed;
    [SerializeField] float damage;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    public void Init(bool isRight, float bombSpeed)
    {
        // AddForce
        if (isRight)
        {
            rigid.AddForce(new Vector2(-1,1) * bombSpeed, ForceMode2D.Impulse);
        }
        else
        {
            rigid.AddForce(new Vector2(1, 1) * bombSpeed, ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("EnemyAttack"))
        {
            Vector2 knockbackDir = (transform.position - collision.transform.position).normalized; // 방향 계산

            rigid.AddForce(new Vector2(knockbackDir.x,1) * bombSpeed * addSpeed, ForceMode2D.Impulse);
        }
    }

}
