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
        // bomb 위치 BigGuy PickPos로 이동하게
        hitCollider.transform.position = pickPos.position;

        // bomb Collider2D 를 끄고 rigid 의 bodyType을 Kinematic 으로 변경

        animator.SetTrigger("Throw");

        //bomb Collider2D 를 키고 rigid 의 bodyTpye을 Dynamic 으로 변경

        // BaldPirate Attack 처럼 날아가게

    }
}
