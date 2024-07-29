using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rb;
    private float _velocity = 2.25f;
    private float _rotaionSpeed = 10f;

    public GameObject smokePrefab;
    public GameObject enviroment;

    public AudioClip collectStarSound, flySound, deathSound;
    private AudioSource _audioSource;

    void Start()
    {
        // todo refactor
        if (Screen.height > Screen.width)
        {
            gameObject.transform.localScale = new Vector3(0.7f, 0.7f, 1);
        }
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
            _audioSource.PlayOneShot(flySound);
            _rb.velocity = Vector2.up * _velocity;
            Instantiate(smokePrefab, transform.Find("Smoke").transform.position, transform.rotation, enviroment.transform);
        }
  
    }

    private void FixedUpdate() {
        transform.rotation = Quaternion.Euler(0, 0, _rb.velocity.y * _rotaionSpeed);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        _audioSource.PlayOneShot(deathSound);
        GameManager.instance.GameOver();
    }

    public void PlayCollectStarSound()
    {
        _audioSource.PlayOneShot(collectStarSound);
    }
}
