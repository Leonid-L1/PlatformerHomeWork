using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out GemsCollect player))
        {
            Destroy(gameObject);
            player.IncreaseGemCount();
        }
    }
}
