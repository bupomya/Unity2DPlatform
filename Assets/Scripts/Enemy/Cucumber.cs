using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cucumber : EnemyAttack
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


        
    }

    protected override void BombAttack(Collider2D hitCollider)
    {
        animator.SetTrigger("Attack");
    }
}
