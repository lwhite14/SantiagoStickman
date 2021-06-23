using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rigid;
    public float speed;
    [HideInInspector]
    public bool isLanded = true;
    float xMove;

    [Header("Jumping Variables")]
    public float jumpForce;
    public float groundedRememberTime = 0.2f;
    float groundedRemember = 0f;
    public float jumpPressedTimer = 0.2f;
    float jumpPressedRemeber = 0f;
    public float cutJumpHeight = 0.5f;

    [Header("Animation Variables")]
    public Animator anim;
    public float smoothIdleTimer = 0.2f;
    float smoothIdle;

    void Start()
    {
        smoothIdle = smoothIdleTimer;
    }

    void Update()
    {
        HorizontalMovement();
        Jump();
        Animation();

        Debug.Log(smoothIdleTimer);
    }

    void HorizontalMovement() 
    {
        xMove = Input.GetAxisRaw("Horizontal");
        transform.position = new Vector3(transform.position.x + (xMove * Time.deltaTime * speed), transform.position.y, 0);
    }

    void Jump()
    {
        groundedRemember -= Time.deltaTime;
        jumpPressedRemeber -= Time.deltaTime;

        if (isLanded)
        {
            groundedRemember = groundedRememberTime;
        }    
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpPressedRemeber = jumpPressedTimer;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (!isLanded)
            {
                rigid.velocity = new Vector2(rigid.velocity.x, rigid.velocity.y * cutJumpHeight);
            }
        }

        if ((jumpPressedRemeber > 0) && (groundedRemember > 0) && isLanded)
        {
            jumpPressedRemeber = 0f;
            groundedRemember = 0f;
            rigid.AddForce(transform.up * jumpForce);

        }

    }

    void Animation() 
    {
        if (xMove != 0)
        {
            smoothIdleTimer = smoothIdle;
            anim.SetBool("isRunning", true);
            if (xMove > 0)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
            else 
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
        }
        else
        {
            smoothIdleTimer -= Time.deltaTime;
            if (smoothIdleTimer < 0)
            {
                anim.SetBool("isRunning", false);
            }
        }
    }

    public void SetIsLanded(bool newIsLanded) 
    {
        isLanded = newIsLanded;
    }
}
