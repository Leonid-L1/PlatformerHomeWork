using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestruction : MonoBehaviour
{
    public void Die()
    {
        Destroy(gameObject);
    }
}
