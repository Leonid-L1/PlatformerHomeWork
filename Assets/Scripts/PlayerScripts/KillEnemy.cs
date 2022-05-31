using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemy : MonoBehaviour
{
    private int _firstContanctPointIndex = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var enemy = collision.collider.GetComponent<EnemyDestruction>();

        if (enemy != null)
        {
            ContactPoint2D point = collision.GetContact(_firstContanctPointIndex);

            if (point.normal.y >= Vector2.up.y)
            {
                enemy.Die();
            }
        }
    }
}
