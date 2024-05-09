using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    Rigidbody2D rigid;
    [SerializeField] float bulletSpeed;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = transform.position * bulletSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
