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
        //Invoke("RandomMove", 2f);
        transform.Translate(moveDir * moveSpeed * Time.deltaTime);

    }

    void ChangeDir()
    {
        moveDir.x *= -1;
        transform.localScale = new Vector2(moveDir.x, 1);
    }


}
