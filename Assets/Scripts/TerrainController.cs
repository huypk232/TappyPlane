using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainController : MonoBehaviour
{
    // private float speed = 1f;
    // private bool childSpawn = false;

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * Time.deltaTime; 
        
    }
}
