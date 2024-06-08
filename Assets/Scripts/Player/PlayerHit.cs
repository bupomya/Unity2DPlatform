using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : Health
{
    [SerializeField] float knockbackForce;// 힘
    [SerializeField] float knockbackDuration;// 지속시간
    [SerializeField] float knockbackTimer;// 타이머
    [SerializeField] bool isKnockback; // 상태체크
    
    // Update is called once per frame
    void Update()
    {
        if (isKnockback)
        {
            
            knockbackTimer -= Time.deltaTime;

            if(knockbackTimer <= 0)
            {
                isKnockback = false;
            }
        }
    }

    public void TakeDamage(Vector2 direction)
    {
        
    }
}
