using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigGuy : EnemyAttack
{
    [SerializeField] protected Transform pickPos;
    [SerializeField] protected Transform ThrowPos;

    //[SerializeField] Bomb bombPos;

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

    }

    protected override void BombAttack(Collider2D hitCollider)
    {
        
        animator.SetTrigger("Pick");
        // bomb ��ġ BigGuy PickPos�� �̵��ϰ�
        hitCollider.transform.position = pickPos.position;

        // bomb Collider2D �� ���� rigid �� bodyType�� Kinematic ���� ����

        animator.SetTrigger("Throw");

        //bomb Collider2D �� Ű�� rigid �� bodyTpye�� Dynamic ���� ����

        // BaldPirate Attack ó�� ���ư���

    }
}
