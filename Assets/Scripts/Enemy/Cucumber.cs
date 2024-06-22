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
        if (isAttack)
        {
            Attack();
        }
    }

    protected override void Attack()
    {


        animator.SetTrigger("Attack");
    }
}
