using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindMill : MonoBehaviour
{
    float zRotation;
    void Update()
    {
        zRotation += Time.deltaTime * 60;
        transform.eulerAngles = new Vector3(0, 0, zRotation);
    }
}
