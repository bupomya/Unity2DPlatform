using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InputMoveMent : MoveMent
{
    [SerializeField] float moveInput;

    [SerializeField] float jumpPower;

    [SerializeField] private LayerMask groundLayer; // ground 레이어

    private bool jumpRequested; // 점프요청을 저장할 플래그
    [SerializeField] int jumpCount; // 남은 점프 횟수
    [SerializeField] int maxJumpCount; // 최대 점프 횟수
    [SerializeField] Transform groundCheck; // groundcheck 위치
    [SerializeField] float groundCheckRadius; //groundCheck 범위

    [SerializeField] private bool isGround;
    public bool IsGround { get => isGround; set => isGround = value; }
    

    protected override void Awake()
    {
        base.Awake(); // MoveMent의 Awake() 먼저 실행
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
            jumpCount--; // FixedUpdate에서 처리 해야함 Update 에서 처리하면 컴퓨터 사양에 따라 frame이 달라서
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
        Vector3 playerScale = transform.localScale;// 자신의 localScale 을 담음
        playerScale.x *= -1; // localScale.x 값에 -1 을 곱해 반대로 뒤집어줌 (SpriteRenderer에 Flip이랑 똑같이 보임)
        transform.localScale = playerScale; // 바뀐값을 넣음
        IsRight = !IsRight; // 뒤집어진 값을 상속받은 isRight 값을 set 함
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
