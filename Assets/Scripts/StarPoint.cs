using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.TryGetComponent<Player>(out Player player))
        {
            player.PlayCollectStarSound();
            GameManager.instance.IncreaseScore(1);
            Destroy(gameObject);
        }
    }
}
