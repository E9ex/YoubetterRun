using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private float turnspeed = 90f;
   

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0,turnspeed*Time.deltaTime);
    }
}
