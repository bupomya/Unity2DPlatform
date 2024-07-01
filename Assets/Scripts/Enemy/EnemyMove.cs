using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyMove : MoveMent
{
    [SerializeField] int nextMove;
    [SerializeField] float enemyMoveTime;
    [SerializeField] EnemyAttack enemyAttack;

    private void Awake()
    {
        base.Awake();
        Invoke("Think", enemyMoveTime);
    }

    private void FixedUpdate()
    {
        Move();
    }

    protected override void Move()
    {
        if (!enemyAttack.isAttack && !enemyAttack.isPickBomb)
        {
            //Move
            rigid.velocity = new Vector2(nextMove, rigid.velocity.y);

            //Platform Check
            Vector2 frontVec = new Vector2(rigid.position.x + nextMove, rigid.position.y);
            Debug.DrawRay(frontVec, Vector3.down, new Color(0, 1, 0));

            RaycastHit2D hit = Physics2D.Raycast(frontVec, Vector3.down, 2);
            //, LayerMask.GetMask("TurnPoint")

            if (hit.collider != null && hit.collider.CompareTag("TurnPoint"))
            {
                Turn();
            }
        }
    }

    private void Flip()
    {
        Vector3 EnemyScale = transform.localScale;
        EnemyScale.x *= -1;
        transform.localScale = EnemyScale;
        IsRight = !IsRight;
        MoveDir *= -1;
    }

    private void Turn()
    {
        nextMove *= -1;
        //spriteRenderer.flipX = nextMove == 1;
        Flip();

        CancelInvoke();
        Invoke("Think", enemyMoveTime);
    }

    void Think()
    {
        //nextMove = Random.Range(-1, 2);


        animator.SetInteger("isRun", nextMove);

        Invoke("Think", enemyMoveTime);
    }

}
