using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject groundTile;
    private Vector3 NextSpawnPoint;
    

    private void Start()
    {
        spawnTile();
        spawnTile();
        spawnTile();
        
    }

    public void spawnTile()
    {
       GameObject temp=Instantiate(groundTile, NextSpawnPoint, Quaternion.identity);
       NextSpawnPoint = temp.transform.GetChild(0).transform.position;
    }
}
