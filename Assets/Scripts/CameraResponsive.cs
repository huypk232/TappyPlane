using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraResponsive : MonoBehaviour
{
    [SerializeField] private Vector3 mobileCenterCamera;
    
    void Start()
    {
        // RepositionCamera();
    }

    void Update()
    {
        
    }

    private void RepositionCamera()
    {
        if (Screen.height > Screen.width)
        {
            gameObject.transform.position = mobileCenterCamera;
        }
    }
}
