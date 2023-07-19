using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoke : MonoBehaviour
{
    void Update()
    {
        Destroy(gameObject, 1f);
    }
}
