using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaldPirate : EnemyAttack
{
    
    private void Awake()
    {
        base.Awake();
    }

    private void Update()
    {
        base.Update();
    }

    protected override void Attack()
    {
        animator.SetTrigger("Attack");
        Invoke("SetIsAttack", 1f);
    }

    protected override void BombAttack(Collider2D hitCollider)
    {
        animator.SetTrigger("Attack");
        Invoke("SetIsAttack", 1f);
    }

    void SetIsAttack()
    {
        if (isAttack) isAttack = false;
        if (isPickBomb) isPickBomb = false;
    }

}
