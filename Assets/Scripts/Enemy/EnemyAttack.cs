using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAttack : MonoBehaviour
{
    [SerializeField] float damage;
    [SerializeField] Transform attackPos;
    Animator animator;


    protected virtual void Awake()
    {
        animator = GetComponent<Animator>();
    }

    protected abstract void Attack();
}
