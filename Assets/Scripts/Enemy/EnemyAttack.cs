using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public abstract class EnemyAttack : MonoBehaviour
{
    public float damage;

    [SerializeField] protected Transform attackPos;

    public bool isAttack;
    public bool isPickBomb;

    [SerializeField] protected float attackCheckRadius;
    [SerializeField] protected LayerMask attackLayer;

    [SerializeField] protected float ActionTime;

    protected Animator animator;

    protected virtual void Awake()
    {
        animator = GetComponent<Animator>();
    }


    protected virtual void Update()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(attackPos.position, attackCheckRadius, attackLayer);
        ColliderCheck(hitColliders);
    }

    protected void ColliderCheck(Collider2D[] hitColliders)
    {

        // �浹ü üũ
        foreach (var hitCollider in hitColliders)
        {
            // �浹�� ���ӿ�����Ʈ�� �÷��̾��
            if (hitCollider.CompareTag("Bomb"))
            {
                isPickBomb = true;
                BombAttack(hitCollider);
                break;
            }
            else if (hitCollider.CompareTag("Player"))
            {
                isAttack = true;
                Attack();
                break;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackCheckRadius);
    }


    protected abstract void Attack();
    protected abstract void BombAttack(Collider2D hitCollider);
}
