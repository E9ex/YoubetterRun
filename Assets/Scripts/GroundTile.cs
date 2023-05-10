using System;
using UnityEngine;
using Random = UnityEngine.Random;


public class GroundTile : MonoBehaviour
{
    private GroundSpawner _groundSpawner;
    public GameObject obstaclePrefab;

    private void Start()
    {
        _groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        spawnObstacle();
    }

    private void OnTriggerExit(Collider other)
    {
        _groundSpawner.spawnTile();
        Destroy(gameObject,2f);
    }

    void spawnObstacle()
    {
        int ObsIndex = Random.Range(2, 5);//ındis numarasından dolayı bu sekilde
        Transform spawnPoint = transform.GetChild(ObsIndex).transform;
        Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity,transform);
    }


}
