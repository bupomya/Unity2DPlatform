using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MoveMent
{

    private void Update()
    {
        Move();
        if(Input.GetKeyDown(KeyCode.Backspace))
        {
            ChangeDir();
        }
    }

    protected override void Move()
    {
        transform.Translate(moveDir * moveSpeed * Time.deltaTime);
    }

    void ChangeDir()
    {
        moveDir.x *= -1;
        transform.position = new Vector2(moveDir.x, 0);
    }
}
