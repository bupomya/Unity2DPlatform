using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] protected int hp;


    public void hit(int damage)
    {
        hp -= damage;

        if(hp <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        //die animation
    }
}
