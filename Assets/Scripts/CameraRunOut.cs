using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRunOut : MonoBehaviour
{
    void Update()
    {
        Vector3 camPos = Camera.main.WorldToViewportPoint(transform.position);
        if(camPos.x < -2)
        {
            Destroy(gameObject);
        }
    }
}
