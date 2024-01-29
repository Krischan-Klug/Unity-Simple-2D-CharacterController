using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 3f;
    public float walkSpeed = 3f;
    public float MoveX;
    public float MoveY;
    public Vector2 Movement;
    private bool stopMoving = true;
    private bool isDead = false;

    private Rigidbody2D rb;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        GetInput();
        Move();
    }

    void GetInput()
    {
        MoveX = Input.GetAxisRaw("Horizontal");
        MoveY = Input.GetAxisRaw("Vertical");
        Movement = new Vector2(MoveX, MoveY);

    }

    void Move()
    {
        if (Movement != Vector2.zero)
        {

            if (isDead == false)
            {
                stopMoving = false;
                rb.velocity = Movement.normalized * speed;
				
		//animation 
		animator.SetFloat("moveY", MoveY);
                animator.SetFloat("moveX", MoveX);
                animator.SetBool("moving", true);

            }

        }

        MoveExit();

    }

    private void MoveExit()
    {

        if (Movement == Vector2.zero && stopMoving == false)
        {

        	stopMoving = true;           
            	rb.velocity = Vector2.zero;
			
		//animation
		animator.SetBool("moving", false);
           
        }
    }
}
