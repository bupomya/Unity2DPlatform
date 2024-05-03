using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ImputMoveMent : MoveMent
{
    [SerializeField] float moveInput;
    [SerializeField] float JumpPower;
    [SerializeField] bool isJump;
    [SerializeField] protected bool isRun;

    [SerializeField] private bool isGround = true;
    public bool IsGround { get => isGround; set => isGround = value; }

    protected override void Awake()
    {
        base.Awake(); // MoveMent�� Awake() ���� ����
    }

    void Update()
    {
        animator.SetFloat("YVelocity", rigid.velocity.y);

        Jump();
        Move();
        ChangeDir();
        MoveAnimation();
    }

    protected override void Move()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rigid.velocity = new Vector2(moveInput * moveSpeed, rigid.velocity.y);
        //isRun = moveInput != 0 ? isRun : !isRun;
        if(moveInput != 0)
        {
            isRun = true;
        }
        else
        {
            isRun = false;
        }
    }

    void ChangeDir()
    {
        if ((IsRight && moveInput > 0) || (!IsRight && moveInput < 0))
        {
            Flip();
        }
    }

    void MoveAnimation()
    {

        bool Run = moveInput != 0;


        if (Run)
            animator.SetBool("Run", Run);
        else
            animator.SetBool("Run", Run);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && !isJump)
        {
            
            isJump = true;

            Vector3 dir = new Vector3(rigid.velocity.y, 0);
            rigid.velocity = dir;
            rigid.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
            animator.SetBool("Jumping", true);
        }
    }


    private void Flip()
    {
        Vector3 playerScale = transform.localScale;// �ڽ��� localScale �� ����
        playerScale.x *= -1; // localScale.x ���� -1 �� ���� �ݴ�� �������� (SpriteRenderer�� Flip�̶� �Ȱ��� ����)
        transform.localScale = playerScale; // �ٲﰪ�� ����
        IsRight = !IsRight; // �������� ���� ��ӹ��� isRight ���� set ��
    }



    // OnTrigger �� �浹�ϴ� �� ��ü�� collider ������Ʈ�� �����ϸ鼭
    // �Ѱ� �̻��� colllider ������Ʈ�� isTrigger�� Ȱ��ȭ �����־����

    // Oncollision �� �浹�ϴ� �� ��ü�� collider ������Ʈ�� �����ϸ鼭
    // �� ��ü�� colllider ������Ʈ�� �ִ� isTrigger�� ��Ȱ��ȭ �����־����

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Plat"))
        {
            isJump = false;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Plat"))
        {
            IsGround = true;

            animator.SetBool("Jumping", false);
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Plat"))
        {
            IsGround = false;

        }
    }

}
