using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*[Serializable]
public struct BombInfo
{
    public bool isRight;
    public float speed;
    public float maxSpeed;
} 
*/

public class PlayerAttack : MonoBehaviour
{
    //[SerializeField] float deg;

    [SerializeField] GameObject Bomb;
    [SerializeField] GameObject bombPos;
    [SerializeField] bool isSpace; // space ��¡ ����

    //public BombInfo bombInfo; // ������, ��������

    [SerializeField] float addSpeed;
    float bombSpeed = 0f;
    [SerializeField] private float maxBombSpeed;

    private InputMoveMent movement;

    private void Awake()
    {
        movement = GetComponent<InputMoveMent>();
    }
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            isSpace = true;
            Debug.Log($"start : {bombSpeed}");
        }

        if (isSpace && Input.GetKeyUp(KeyCode.Space)) // ������ �ִ� �ð��� ���� �ָ� ���ư���
        {
            Debug.Log($"end : {bombSpeed}");

            //bombInfo.isRight = movement.IsRight;

            GameObject bomb = Instantiate(Bomb,bombPos.transform.position, bombPos.transform.rotation);
            bomb.GetComponent<Bomb>().Init(movement.IsRight, bombSpeed);
            bombSpeed = 0f;
            isSpace = false;
        }
    }

    private void FixedUpdate()
    {
        if (isSpace && bombSpeed < maxBombSpeed)
        {
            bombSpeed += (Time.fixedDeltaTime * addSpeed);
            Debug.Log($"process : {bombSpeed}");
        }
    }
}