using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCircleMove : MonoBehaviour
{
    [SerializeField] float deg;
    [SerializeField] float objcetSpeed;
    [SerializeField] GameObject spike;
    
    void Update()
    {
        deg = deg + Time.deltaTime * objcetSpeed;
        float rad = deg * Mathf.Deg2Rad;
        spike.transform.localPosition = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad));
        spike.transform.eulerAngles = new Vector3(0, 0, deg);
    }
}
