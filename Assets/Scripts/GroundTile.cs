using System;
using UnityEngine;
using Random = UnityEngine.Random;


public class GroundTile : MonoBehaviour
{
    private GroundSpawner _groundSpawner;
    public GameObject []obstaclePrefab;
    public GameObject obstaclePrefab2;
    //private int currentobstacleIndex = 0; 
    

    private void Start()
    {
        _groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        spawnObstacle();
        spawnObstacleWithEnemy();
    }

    private void OnTriggerExit(Collider other)
    {
        _groundSpawner.spawnTile();
        Destroy(gameObject,2f);
    }

    void spawnObstacle()
    {
        int ObsIndex = Random.Range(2, 4);//ındis numarasından dolayı bu sekilde engeller bu .
        Transform spawnPoint = transform.GetChild(ObsIndex).transform;
        for (int i = 0; i < 2; i++)
        {
            int randomIndex = Random.Range(0, obstaclePrefab.Length);
            Instantiate(obstaclePrefab[randomIndex], spawnPoint.position, Quaternion.identity);
        }
       // Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity,transform);
        
    }

    void spawnObstacleWithEnemy()
    {
        int ObsenemyIndex =Random.Range(5, 7);//4;
        Transform spawnPoint = transform.GetChild(ObsenemyIndex).transform;
        Instantiate(obstaclePrefab2, spawnPoint.position, Quaternion.identity,transform);
    }


}
