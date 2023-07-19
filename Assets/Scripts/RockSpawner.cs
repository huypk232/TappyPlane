using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    public GameObject ground;
    public GameObject topPrefab; // original scale 1.2f
    public GameObject botPrefab;
    public GameObject starPointPrefab;
    [SerializeField] float maxHorizonDistance;
    [SerializeField] float minHorizonDistance;
    private float spawnTime;
    [SerializeField] float speedUpRange;
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




    void Update()
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
        Instantiate(topPrefab, new Vector3(transform.position.x, verticalPos, 0f), Quaternion.identity, ground.transform);
        Instantiate(starPointPrefab, new Vector3(transform.position.x, -_cameraHeight / 2 + (_cameraHeight - 2.4f * randomVerticalScale) / 2, 0f), Quaternion.identity, ground.transform);
    }

    private void RandomBotRock()
    {
        float randomVerticalScale = Random.Range(0.5f, 1.5f);
        Vector3 scaleChange = new Vector3(1f, randomVerticalScale, 1f);
        botPrefab.transform.localScale = scaleChange;
        float verticalPos = -_cameraHeight / 2 + 1.2f * randomVerticalScale;
        Instantiate(botPrefab, new Vector3(transform.position.x, verticalPos, 0f), Quaternion.identity, ground.transform);
        Instantiate(starPointPrefab, new Vector3(transform.position.x, _cameraHeight / 2 - (_cameraHeight - 2.4f * randomVerticalScale) / 2, 0f), Quaternion.identity, ground.transform);
    }

    private void RandomStarpoint()
    {
        if(_leftStarPosX != _rightStarPosX)
        {
            // Instantiate(starPointPrefab, new Vector3(trans))
        }
    }
}
