using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public Rigidbody2D rigid;
    public float bombSpeed;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    public void Init(bool isRight)
    {
        // AddForce
        if (isRight)
        {
            rigid.AddForce(transform.forward * bombSpeed, ForceMode2D.Impulse);
        }
        else
        {
            rigid.AddForce(-transform.forward * bombSpeed, ForceMode2D.Impulse);
        }
    }

    void Start()
    {
        //if (movement.isright)
        //    rigid.velocity = transform.position * bombSpeed;
        //else
        //    rigid.velocity = -transform.position * bombSpeed;
        // 터질때는 overlap 사용해서
    }

}
