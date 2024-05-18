using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public Rigidbody2D rigid;
    public float bombSpeed = 10;
    public float maxBombSpeed;
    [SerializeField] float damage;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
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
