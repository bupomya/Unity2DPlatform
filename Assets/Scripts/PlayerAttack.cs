using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    //[SerializeField] float deg;

    [SerializeField] GameObject Bomb;
    [SerializeField] GameObject bombPos;

    private InputMoveMent movement;

    private void Awake()
    {
        movement = GetComponent<InputMoveMent>();
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject go = Instantiate(Bomb,bombPos.transform.position, bombPos.transform.rotation);
            go.GetComponent<Bomb>().Init(movement.IsRight);

        }
    }
}
