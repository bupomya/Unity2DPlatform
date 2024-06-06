using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InputMoveMent : MoveMent
{
    [SerializeField] float moveInput;

    [SerializeField] float jumpPower;

    [SerializeField] private LayerMask groundLayer; // ground ���̾�

    private bool jumpRequested; // ������û�� ������ �÷���
    [SerializeField] int jumpCount; // ���� ���� Ƚ��
    [SerializeField] int maxJumpCount; // �ִ� ���� Ƚ��
    [SerializeField] Transform groundCheck; // groundcheck ��ġ
    [SerializeField] float groundCheckRadius; //groundCheck ����

    [SerializeField] private bool isGround;
    public bool IsGround { get => isGround; set => isGround = value; }
    

    protected override void Awake()
    {
        base.Awake(); // MoveMent�� Awake() ���� ����
    }

    private void Start()
    {
        jumpCount = maxJumpCount;
    }

    void Update()
    {
        animator.SetFloat("YVelocity", rigid.velocity.y);
        animator.SetBool("isGround", IsGround);
        IsGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (IsGround)
            jumpCount = maxJumpCount;

        Move();

        if (Input.GetKeyDown(KeyCode.UpArrow) && jumpCount > 0)
        {
            jumpRequested = true;
        }

        ChangeDir();
    }
    private void FixedUpdate()
    {
        if (jumpRequested)
        {
            rigid.velocity = new Vector2(rigid.velocity.x, jumpPower);
            jumpCount--; // FixedUpdate���� ó�� �ؾ��� Update ���� ó���ϸ� ��ǻ�� ��翡 ���� frame�� �޶�
            animator.SetTrigger("isJump");
            jumpRequested = false;
        }
    }

    protected override void Move()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        MoveDir = new Vector2(moveInput, 0);
        rigid.velocity = new Vector2(moveInput * moveSpeed, rigid.velocity.y);
        animator.SetFloat("Run", Mathf.Abs(moveInput));

        
    }


    void ChangeDir()
    {
        if ((IsRight && moveInput > 0) || (!IsRight && moveInput < 0))
        {
            Flip();
        }
    }

    private void Flip()
    {
        Vector3 playerScale = transform.localScale;// �ڽ��� localScale �� ����
        playerScale.x *= -1; // localScale.x ���� -1 �� ���� �ݴ�� �������� (SpriteRenderer�� Flip�̶� �Ȱ��� ����)
        transform.localScale = playerScale; // �ٲﰪ�� ����
        IsRight = !IsRight; // �������� ���� ��ӹ��� isRight ���� set ��
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
