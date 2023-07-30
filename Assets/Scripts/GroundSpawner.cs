using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField] GameObject terrain;
    [SerializeField] GameObject groundPrefab;

    private float speed = 7f;

    private float deltaTimeSpeed;

    private void Start() {
        deltaTimeSpeed = 0;
    }

    void Update()
    {
        deltaTimeSpeed -= Time.deltaTime;
        if(deltaTimeSpeed <= 0f)
        {
            Instantiate(groundPrefab, new Vector3(transform.position.x + 8, transform.position.y, 0), Quaternion.identity, terrain.transform);
            deltaTimeSpeed = speed;
        }
    }
}
