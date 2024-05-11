using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    //[SerializeField] float deg;

    [SerializeField] GameObject Bomb;
    [SerializeField] GameObject bombPos;
    [SerializeField] bool isSpace; // space 차징 시작 단계

    private InputMoveMent movement;

    private void Awake()
    {
        movement = GetComponent<InputMoveMent>();
    }
    
    void Update()
    {
        if (isSpace) // 누르고 있는 시간에 따라 멀리 날아가게
        {
            GameObject go = Instantiate(Bomb,bombPos.transform.position, bombPos.transform.rotation);
            go.GetComponent<Bomb>().Init(movement.IsRight);
        }
    }
}
