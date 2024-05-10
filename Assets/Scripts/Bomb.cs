using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public Rigidbody2D rigid;
    public float bulletSpeed;
    InputMoveMent movement;

    private void Awake()
    {
        movement = GetComponent<InputMoveMent>();
    }

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        if (movement.IsRight) // 
            rigid.velocity = transform.position * bulletSpeed;
        else
            rigid.velocity = -transform.position * bulletSpeed;
    }

}
