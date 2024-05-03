using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public abstract class MoveMent : MonoBehaviour
{
    // SpriteRenderer, Rigidbody2D, Animator ������Ʈ
    protected SpriteRenderer SpriteRenderer;
    protected Rigidbody2D rigid;
    protected Animator animator;

    // �ٶ󺸴� ���� üũ
    private bool isRight;
    public bool IsRight { get => isRight; set => isRight = value; }

    //�̵� ����
    [SerializeField] protected Vector2 moveDir;
    public Vector2 MoveDir { get => moveDir; set => moveDir = value; }

    [SerializeField] protected float moveSpeed;

     protected virtual void Awake()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // �߻� �޼ҵ� (��� ���� ������ �ݵ�� ó���ؾ���)
    protected abstract void Move();
}
