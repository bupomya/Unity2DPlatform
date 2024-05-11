using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public Rigidbody2D rigid;
    public float bombSpeed;
    [SerializeField] float damage;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    public void Init(bool isRight)
    {
        // AddForce
        if (isRight)
        {
            rigid.AddForce(new Vector2(-1,1) * bombSpeed, ForceMode2D.Impulse);
            //rigid.velocity = transform.position * bombSpeed;
        }
        else
        {
            rigid.AddForce(new Vector2(1, 1) * bombSpeed, ForceMode2D.Impulse);
            //rigid.velocity = -transform.position * bombSpeed;
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
