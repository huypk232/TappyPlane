using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class RockSpawner : MonoBehaviour
{
    public GameObject terrain;
    public GameObject topPrefab; // original scale 1.2f
    public GameObject botPrefab;
    public GameObject starPointPrefab;
    [SerializeField] private GameObject pairOfPeaksPrefab;

    [SerializeField] float maxHorizonDistance;
    [SerializeField] float minHorizonDistance;
    [SerializeField] float speedUpRange;

    private float oldHeight;
    private float spawnTime;
    private float _leftStarPosX;
    private float _rightStarPosX;

    private float _cameraHeight;
    private bool _grounded = false;

    void Start()
    {
        _leftStarPosX = 0;
        _rightStarPosX = 0;
        spawnTime = Random.Range(minHorizonDistance, maxHorizonDistance);
        _cameraHeight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0)).y * 2 + 0.1f;
    }

    private void OnEnable()
    {
        InvokeRepeating("SpawnPairOfPeaks", 0.0f, 1.5f);
    }

    void Update()
    {
        // SpawnPairOfPeaks();
    }

    private void SpawnRandomDirection()
    {
        spawnTime -= Time.deltaTime;
        if(spawnTime <= 0)
        {
            if (_grounded)
            {
                
                RandomTopRock();
            }
            else
            {
                RandomBotRock();
            }
            _grounded = !_grounded;
            _rightStarPosX = _leftStarPosX;
            _leftStarPosX = transform.position.x;
            spawnTime = Random.Range(minHorizonDistance, maxHorizonDistance);
        }
    }
    
    private void RandomTopRock()
    {
        float randomVerticalScale = Random.Range(0.5f, 1.5f);
        Vector3 scaleChange = new Vector3(1f, randomVerticalScale, 1f);
        topPrefab.transform.localScale = scaleChange;
        float verticalPos = _cameraHeight / 2 - 1.2f * randomVerticalScale;
        Instantiate(topPrefab, new Vector3(transform.position.x, verticalPos, 0f), Quaternion.identity, terrain.transform);
        Instantiate(starPointPrefab, new Vector3(transform.position.x, -_cameraHeight / 2 + (_cameraHeight - 2.4f * randomVerticalScale) / 2, 0f), Quaternion.identity, terrain.transform);
    }

    private void RandomBotRock()
    {
        float randomVerticalScale = Random.Range(0.5f, 1.5f);
        Vector3 scaleChange = new Vector3(1f, randomVerticalScale, 1f);
        botPrefab.transform.localScale = scaleChange;
        float verticalPos = -_cameraHeight / 2 + 1.2f * randomVerticalScale;
        Instantiate(botPrefab, new Vector3(transform.position.x, verticalPos, 0f), Quaternion.identity, terrain.transform);
        Instantiate(starPointPrefab, new Vector3(transform.position.x, _cameraHeight / 2 - (_cameraHeight - 2.4f * randomVerticalScale) / 2, 0f), Quaternion.identity, terrain.transform);
    }

    private void SpawnPairOfPeaks()
    {
        var newHeight = Random.Range(-2.5f, 2.5f);
        var safeIndex = 100;
        while (Mathf.Abs(oldHeight - newHeight) > 2.5 && safeIndex > 0)
        {
            newHeight = Random.Range(-2.5f, 2.5f);
            safeIndex--;
        }

        oldHeight = newHeight;
        Instantiate(pairOfPeaksPrefab, new Vector3(transform.position.x, newHeight, 0), Quaternion.identity, terrain.transform);
    }
}
