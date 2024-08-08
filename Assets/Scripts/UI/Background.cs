using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private Camera camera;
    [SerializeField] private float speed;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _renderer.material.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0);
    }
}
