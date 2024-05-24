using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator animator;

    public float bombSpeed = 10;
    public float maxBombSpeed;
    [SerializeField] float damage;


    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    public void Init(bool isRight, float bombSpeed)
    {
        // AddForce
        if (isRight)
        {
            rigid.AddForce(new Vector2(-1,1) * bombSpeed, ForceMode2D.Impulse);
        }
        else
        {
            rigid.AddForce(new Vector2(1, 1) * bombSpeed, ForceMode2D.Impulse);
        }
    }

}
