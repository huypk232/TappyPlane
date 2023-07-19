using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRunOut : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 camPos = Camera.main.WorldToViewportPoint(transform.position);
        if(camPos.x < -1)
        {
            Destroy(gameObject);
        }
    }
}
