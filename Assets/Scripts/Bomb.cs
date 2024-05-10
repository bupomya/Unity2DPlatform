using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    Rigidbody2D rigid;
    [SerializeField] float bulletSpeed;


    [SerializeField] Transform playerTransform;
    [SerializeField] float playerDir;


    private void Awake()
    {
        playerTransform = GetComponentInParent<Transform>();
    }

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = playerTransform.right * bulletSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
