using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform[] groundChecks;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Transform cloneObject;


    private float horizontal;
    private float speed = 8f;
    private float jumpPower = 16f;

    public void Reset(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            rb.position = spawnPoint.position;
            rb.velocity = Vector2.zero;

            Transform temp = Instantiate(cloneObject, this.transform.position, Quaternion.identity);
            if (!isFacingRight)
            {
                Vector3 localScale = temp.localScale;
                localScale.x *= -1;
                temp.localScale = localScale;
            }
        }
    }

    private bool isFacingRight = true;

    void Start()
    {
        
    }


    void Update()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        if(!isFacingRight && horizontal > 0f)
        {
            Flip();
        }
        else if(isFacingRight && horizontal < 0f)
        {
            Flip();
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if(context.performed && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }

        if(context.canceled && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }

    private bool IsGrounded()
    {
        bool temp = false;

        for (int i = 0; i < groundChecks.Length; i++)
        {
            if(Physics2D.OverlapCircle(groundChecks[i].position, 0.2f, groundLayer))
            {
                temp = true;
            }
        }
        return temp;
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }
}
