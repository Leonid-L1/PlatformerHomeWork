using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemSpawn : MonoBehaviour
{
    [SerializeField] private GameObject _gem;

    private List<Vector3> _spawnPositions = new List<Vector3>();

    private void Start()
    {
        CreatePositions();
        Spawn();
    }
    private void CreatePositions()
    {
        _spawnPositions.Add(new Vector3(0.5f,0.5f,0));  
        _spawnPositions.Add(new Vector3(-8,0.5f,0));
        _spawnPositions.Add(new Vector3(-11,-6,0));
        _spawnPositions.Add(new Vector3(-6,-8,0));
        _spawnPositions.Add(new Vector3(-10,-11,0));
        _spawnPositions.Add(new Vector3(5,-11,0));
        _spawnPositions.Add(new Vector3(17,-11,0));
    }
    private void Spawn()
    {
        for(int i = 0; i < _spawnPositions.Count; i++)
        {
            GameObject newGem = Instantiate(_gem,_spawnPositions[i],Quaternion.identity);
        }
    }
}
