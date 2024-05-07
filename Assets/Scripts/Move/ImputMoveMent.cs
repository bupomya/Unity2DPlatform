using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ImputMoveMent : MoveMent
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
        Vector3 playerScale = transform.localScale;// �ڽ��� localScale �� ����
        playerScale.x *= -1; // localScale.x ���� -1 �� ���� �ݴ�� �������� (SpriteRenderer�� Flip�̶� �Ȱ��� ����)
        transform.localScale = playerScale; // �ٲﰪ�� ����
        IsRight = !IsRight; // �������� ���� ��ӹ��� isRight ���� set ��
    }


    void ResetJumpCount()
    {
        if (IsGround)
        {
            jumpCount = maxJumpCount;
        }
    }



    // OnTrigger �� �浹�ϴ� �� ��ü�� collider ������Ʈ�� �����ϸ鼭
    // �Ѱ� �̻��� colllider ������Ʈ�� isTrigger�� Ȱ��ȭ �����־����

    // Oncollision �� �浹�ϴ� �� ��ü�� collider ������Ʈ�� �����ϸ鼭
    // �� ��ü�� colllider ������Ʈ�� �ִ� isTrigger�� ��Ȱ��ȭ �����־����

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
