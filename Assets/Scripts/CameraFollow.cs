using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    private Vector3 ofst;
    void Start()
    {
        ofst = transform.position - player.position;
    }

    // Update is called once per frame
    void Update()
    {
      Vector3 targetpos = player.position + ofst;
      targetpos.x = 0;
      transform.position = targetpos;
    }
}
