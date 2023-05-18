using UnityEngine;
public class GroundSpawner : MonoBehaviour
{
    public GameObject groundTile;
    private Vector3 NextSpawnPoint;
    private void Start()
    {
        for (int i = 0; i < 15; i++)
        {
            spawnTile();
        }
    }
    public void spawnTile()
    {
        GameObject temp= Instantiate(groundTile, NextSpawnPoint, Quaternion.identity);
        NextSpawnPoint = temp.transform.GetChild(1).transform.position;
    }
}
