using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public GameObject platform;
    public Transform leftTarget;
    public Transform rightTarget;
    public float speed = 3f;
    float direction = -1f;


    void Update()
    {
        platform.transform.position = new Vector3(platform.transform.position.x + (direction * Time.deltaTime * speed), platform.transform.position.y, 0);
        ChangeDirection();
    }

    void ChangeDirection() 
    {
        if (platform.transform.position.x < leftTarget.position.x) 
        {
            direction = 1f;
        }
        if (platform.transform.position.x > rightTarget.position.x)
        {
            direction = -1f;
        }
    }

}
