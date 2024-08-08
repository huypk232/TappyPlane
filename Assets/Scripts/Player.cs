using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] private float velocity;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Transform smokeDischargePosition;
    
    public GameObject smokePrefab;
    public GameObject enviroment;

    public AudioClip collectStarSound, flySound, deathSound;
    private AudioSource _audioSource;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _rb = GetComponent<Rigidbody2D>();
        _rb.gravityScale =  0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {   
            // start game   
            if(_rb.gravityScale == 0f)
            {
                GameManager.instance.StartGame();
                _rb.gravityScale = 0.65f;
            }

            // _rotaionSpeed = LimitRotateSpeed;
            _audioSource.PlayOneShot(flySound);
            _rb.velocity = Vector2.up * velocity;
            Instantiate(smokePrefab, smokeDischargePosition.position, transform.rotation, enviroment.transform);
        }
  
    }

    private void FixedUpdate()
    {
        var zCorner = _rb.velocity.y * rotationSpeed;
        if (zCorner is >= -90 and <= 90)
        {
            transform.rotation = Quaternion.Euler(0, 0, _rb.velocity.y * rotationSpeed);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 270);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        _audioSource.PlayOneShot(deathSound);
        GameManager.instance.GameOver();
    }

    public void PlayCollectStarSound()
    {
        _audioSource.PlayOneShot(collectStarSound);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.tag);
        {
            PlayCollectStarSound();
            GameManager.instance.IncreaseScore(1);
        }
    }
}
