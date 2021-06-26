using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float smoothing = 5.0f;
    bool stopFollowing = false;
    Vector3 newPos;

    void Update()
    {
        if ((target != null) && (!stopFollowing))
        {
            newPos = new Vector3(target.position.x, target.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, newPos, (smoothing * 0.001f));
        }

        if (target.position.y <= 0)
        {
            stopFollowing = true;
            newPos = new Vector3(target.position.x, 0, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, newPos, (smoothing * 0.001f));
        }
        else
        {
            stopFollowing = false;
        }
    }

    public void SetTarget(Transform newTarget) 
    {
        target = newTarget;
    }

}
