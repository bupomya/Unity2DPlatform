using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeBar : MonoBehaviour
{
    [SerializeField] GameObject followObject;

    void Update()
    {
        Vector3 dir = followObject.transform.position - this.transform.position;

        Vector3 followVector = new Vector3(dir.x, dir.y, 0f);
        this.transform.Translate(followVector);
    }
}
