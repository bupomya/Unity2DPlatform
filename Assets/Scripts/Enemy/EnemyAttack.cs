using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAttack : MonoBehaviour
{
    public float damage;

    [SerializeField] protected Transform attackPos;
    public bool isAttack;
    [SerializeField] protected float attackCheckRadius;
    [SerializeField] LayerMask attackLayer;
    

    protected Animator animator;

    protected virtual void Awake()
    {
        animator = GetComponent<Animator>();
    }

    protected virtual void Update()
    {
        isAttack = Physics2D.OverlapCircle(attackPos.position, attackCheckRadius, attackLayer);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackCheckRadius);
    }


    protected abstract void Attack();
}
