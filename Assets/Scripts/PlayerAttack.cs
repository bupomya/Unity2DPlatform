using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    //[SerializeField] float deg;

    [SerializeField] GameObject Bomb;
    [SerializeField] GameObject bombPos;
    [SerializeField] bool isSpace; // space ��¡ ���� �ܰ�

    private InputMoveMent movement;

    private void Awake()
    {
        movement = GetComponent<InputMoveMent>();
    }
    
    void Update()
    {
        if (isSpace) // ������ �ִ� �ð��� ���� �ָ� ���ư���
        {
            GameObject go = Instantiate(Bomb,bombPos.transform.position, bombPos.transform.rotation);
            go.GetComponent<Bomb>().Init(movement.IsRight);
        }
    }
}
