using UnityEngine;
public class Coin : MonoBehaviour
{
    private float turnspeed = 90f;
    void Update()
    {
        transform.Rotate(0,0,turnspeed*Time.deltaTime);
    }
}
