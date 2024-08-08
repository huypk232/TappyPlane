using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField] GameObject terrain;
    [SerializeField] GameObject groundPrefab;

    [SerializeField] private float speed;

    private float deltaTimeSpeed;

    private void Start() {
        deltaTimeSpeed = 0;
    }

    void Update()
    {
        deltaTimeSpeed -= Time.deltaTime;
        if(deltaTimeSpeed <= 0f)
        {
            Instantiate(groundPrefab, new Vector3(transform.position.x + speed, transform.position.y, 0), Quaternion.identity, terrain.transform);
            deltaTimeSpeed = speed;
        }
    }
}
