using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.TryGetComponent<Player>(out Player player))
        {
            FindObjectOfType<GameManager>().GameOver();
        }
    }
}
