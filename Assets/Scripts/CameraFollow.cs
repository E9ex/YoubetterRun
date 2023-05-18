using UnityEngine;
public class CameraFollow : MonoBehaviour
{
    public Transform player;
    private Vector3 ofst;
    void Start()
    {
        ofst = transform.position - player.position;
    }
    void Update()
    {
      Vector3 targetpos = player.position + ofst;
      targetpos.x = 0;
      transform.position = targetpos;
    }
}
