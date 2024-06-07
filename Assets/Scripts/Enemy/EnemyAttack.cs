using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAttack : MonoBehaviour
{
    [SerializeField] float damage;
    [SerializeField] protected Transform attackPos;
    [SerializeField] protected BoxCollider2D attackCollider;
    protected Animator animator;


    protected virtual void Awake()
    {
        animator = GetComponent<Animator>();
    }

    protected void ObjectCheck()
    {
        //Platform Check
        /*Vector2 frontVec = new Vector2(attackPos.position.x, attackPos.position.y);
        Debug.DrawRay(frontVec, Vector3.down, new Color(1,1,1));

        RaycastHit2D hit = Physics2D.Raycast(frontVec, Vector3.down, 2);*/
    }

    protected abstract void Attack();
}
