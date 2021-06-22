using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rigid;
    public float speed;
    public float jumpForce;
    [HideInInspector]
    public bool isLanded = true;
    float xMove;


    void Update()
    {
        HorizontalMovement();
        Jump();
    }

    void HorizontalMovement() 
    {
        xMove = Input.GetAxisRaw("Horizontal");
        transform.position = new Vector3(transform.position.x + (xMove * Time.deltaTime * speed), transform.position.y, 0);
    }

    void Jump() 
    {
        if (Input.GetKeyDown(KeyCode.Space) && isLanded) 
        {
            rigid.AddForce(transform.up * jumpForce);
        }
    }

    public void SetIsLanded(bool newIsLanded) 
    {
        isLanded = newIsLanded;
    }
}
