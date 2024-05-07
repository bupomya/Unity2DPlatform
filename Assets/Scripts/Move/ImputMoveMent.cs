using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ImputMoveMent : MoveMent
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

    void Update()
    {
        animator.SetFloat("YVelocity", rigid.velocity.y);
        IsGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        
        //Jump();
        Move();
        ChangeDir();
        
        //MoveAnimation();
    }
    private void FixedUpdate()
    {
        if (jumpRequested)
        {
            rigid.velocity = new Vector2(rigid.velocity.x, jumpPower);
            jumpCount--;
            animator.SetTrigger("isJump");
            //rigid.AddForce(Vector2.up * jumpPower);
            jumpRequested = false;
        }
    }

    protected override void Move()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rigid.velocity = new Vector2(moveInput * moveSpeed, rigid.velocity.y);
        animator.SetFloat("Run", Mathf.Abs(moveInput));


        if (Input.GetKeyDown(KeyCode.UpArrow) && jumpCount > 0)
        {
                
                jumpRequested = true;
        }
    }

    /*void Jump()
    {
        Debug.Log("Jump");
        
    }*/

    /*void Jump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && !isJump)
        {
            
            isJump = true;

            Vector3 dir = new Vector3(rigid.velocity.y, 0);
            rigid.velocity = dir;
            rigid.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
            animator.SetBool("Jumping", true);
        }
    }*/

    void ChangeDir()
    {
        if ((IsRight && moveInput > 0) || (!IsRight && moveInput < 0))
        {
            Flip();
        }
    }

    /*void MoveAnimation()
    {

        isRun = moveInput != 0;


        if (isRun)
            animator.SetBool("Run", isRun);
        else
            animator.SetBool("Run", isRun);
    }*/

    void Grounding(bool isGround)
    {
        this.isGround = isGround;
        animator.SetBool("isGround", this.isGround);
    }

    private void Flip()
    {
        Vector3 playerScale = transform.localScale;// 자신의 localScale 을 담음
        playerScale.x *= -1; // localScale.x 값에 -1 을 곱해 반대로 뒤집어줌 (SpriteRenderer에 Flip이랑 똑같이 보임)
        transform.localScale = playerScale; // 바뀐값을 넣음
        IsRight = !IsRight; // 뒤집어진 값을 상속받은 isRight 값을 set 함
    }


    void ResetJumpCount()
    {
        if (IsGround)
        {
            jumpCount = maxJumpCount;
        }
    }



    // OnTrigger 는 충돌하는 두 물체에 collider 컴포넌트가 존재하면서
    // 한개 이상의 colllider 컴포넌트에 isTrigger가 활성화 되이있어야함

    // Oncollision 은 충돌하는 두 물체에 collider 컴포넌트가 존재하면서
    // 두 물체의 colllider 컴포넌트에 있는 isTrigger가 비활성화 되이있어야함

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Plat"))
        {
            Grounding(true);
            ResetJumpCount();

        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Plat"))
        {
            //IsGround = true;

            
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Plat"))
        {
            Grounding(false);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
