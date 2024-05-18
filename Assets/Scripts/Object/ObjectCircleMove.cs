using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCircleMove : MonoBehaviour
{
    [SerializeField] float angle;
    [SerializeField] float objcetSpeed;
    [SerializeField] GameObject spike;
    
    void Update()
    {
        angle = angle + Time.deltaTime * objcetSpeed;
        float rad = angle * Mathf.Deg2Rad;
        spike.transform.localPosition = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad));
        spike.transform.eulerAngles = new Vector3(0, 0, angle);
    }
}
