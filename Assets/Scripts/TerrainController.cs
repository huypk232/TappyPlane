using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainController : MonoBehaviour
{
    void Update()
    {
        transform.position += Vector3.left * (2 * Time.deltaTime); 
    }
}
