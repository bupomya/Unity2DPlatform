using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : Health
{
    [SerializeField] float knockbackForce;// ��
    [SerializeField] float knockbackDuration;// ���ӽð�
    [SerializeField] float knockbackTimer;// Ÿ�̸�
    [SerializeField] bool isKnockback; // ����üũ
    
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
