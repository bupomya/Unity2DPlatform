using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] float deg;

    [SerializeField] GameObject bomb;
    [SerializeField] GameObject bombPos;

    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject go = Instantiate(bomb);
            go.transform.position = bombPos.transform.position;
        }
    }
}