using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 5;
    public Animator animator;
    Vector2 movement;


    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (movement.x == -1)
        {
            animator.SetInteger("Direction", 4);
            Debug.Log("moving left");
        } else if (movement.x == 1)
        {
            animator.SetInteger("Direction", 2);
            Debug.Log("moving right");
        } else if (movement.y == 1)
        {
            animator.SetInteger("Direction", 1);
            Debug.Log("Moving Up");
        } else if (movement.y == -1)
        {
            animator.SetInteger("Direction", 3);
            Debug.Log("Moving Down");
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
