using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    float xMove;
    float yMove;


    void Update()
    {
        HorizontalMovement();
    }

    void HorizontalMovement() 
    {
        xMove = Input.GetAxisRaw("Horizontal");
        transform.position = new Vector3(transform.position.x + (xMove * Time.deltaTime * speed), transform.position.y, 0);
    }
}
