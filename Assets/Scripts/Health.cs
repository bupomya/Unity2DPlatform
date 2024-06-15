using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Health : MonoBehaviour
{
    [SerializeField] protected int hp;
    [SerializeField] protected Animator animator;

    protected virtual void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void SetHp(int damage)
    {
        hp += damage;
    }

    protected abstract void Die();
    
}
