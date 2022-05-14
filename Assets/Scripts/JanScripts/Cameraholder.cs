using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameraholder : MonoBehaviour
{
    float rotationIndex;
    void Update()
    {
        rotationIndex += Time.deltaTime;
        transform.eulerAngles = new Vector3(0, rotationIndex, 0);
    }
}
