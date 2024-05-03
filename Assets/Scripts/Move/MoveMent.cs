using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public abstract class MoveMent : MonoBehaviour
{
    // SpriteRenderer, Rigidbody2D, Animator 컴포넌트
    protected SpriteRenderer SpriteRenderer;
    protected Rigidbody2D rigid;
    protected Animator animator;

    // 바라보는 방향 체크
    private bool isRight;
    public bool IsRight { get => isRight; set => isRight = value; }

    //이동 방향
    [SerializeField] protected Vector2 moveDir;
    public Vector2 MoveDir { get => moveDir; set => moveDir = value; }

    [SerializeField] protected float moveSpeed;

     protected virtual void Awake()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // 추상 메소드 (상속 받은 곳에서 반드시 처리해야함)
    protected abstract void Move();
}
