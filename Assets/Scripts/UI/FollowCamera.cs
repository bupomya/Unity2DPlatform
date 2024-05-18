using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float camSpeed;

    
    void Update()
    {
        Vector3 dir = player.transform.position - this.transform.position;

        Vector3 moveVector = new Vector3(dir.x * camSpeed * Time.deltaTime, dir.y * camSpeed * Time.deltaTime, 0.0f);
        this.transform.Translate(moveVector);
    }
}
