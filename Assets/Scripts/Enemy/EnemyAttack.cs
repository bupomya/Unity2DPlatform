using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public abstract class EnemyAttack : MonoBehaviour
{
    public float damage;

    [SerializeField] protected Transform attackPos;
    public bool isAttack;
    [SerializeField] protected bool isPick;

    [SerializeField] protected float attackCheckRadius;
    [SerializeField] protected LayerMask attackLayer;
    

    protected Animator animator;

    protected virtual void Awake()
    {
        animator = GetComponent<Animator>();
    }

    protected virtual void Update()
    {
        isAttack = Physics2D.OverlapCircle(attackPos.position, attackCheckRadius, attackLayer);
        
    }

    void ColliderCheck()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(attackPos.position, attackCheckRadius, attackLayer);

        // �浹ü üũ
        foreach (var hitCollider in hitColliders)
        {
            // �浹�� ���ӿ�����Ʈ�� �÷��̾��
            if (hitCollider.CompareTag("Bomb"))
            {


                break;
            }
            else if (hitCollider.CompareTag("Player"))
            {

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
}
