using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemsCollect : MonoBehaviour
{
    private int _gemCount = 0;
    
    public void IncreaseGemCount()
    {
        _gemCount++;
        Debug.Log("Gems Count = " + _gemCount);
    }
}
