using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Animator anim;
    // Rigidbody rb;
    // CharacterController controller;

    // public float speed = 5;
    // public float gravity = -5;

    // float yVelocity = 0;


	private Animator animator;
	public float xRotation = 10f;
	public float mouseSensitivity = 100f;
	
	public CharacterController charController;
	public float speed = 12f;
	public float gravity = -10f;
	public float jumpHeight = 2f;

	public Transform groundCheck;
	public float groundDistance = 0.4f;
	public LayerMask groundMask;
	public Vector3 velocity;
	public bool isGrounded;
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // ControllPlayer();
        HandleMovement();
		RotatePlayer();
    }

    void HandleMovement()
	{

		float h;
		float v;
		bool jumpPressed = false;

		h = Input.GetAxis("Horizontal");
		v = Input.GetAxis("Vertical");
		jumpPressed = Input.GetButtonDown("Jump");


		isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

		if (isGrounded && velocity.y < 0)
		{
			velocity.y = -1.4f;
		}

		Vector3 move = transform.right * h + transform.forward * v;


		charController.Move(move * speed * Time.deltaTime);
	

		if (jumpPressed && isGrounded)
		{
			velocity.y = Mathf.Sqrt(jumpHeight * -1.4f * gravity);
			animator.SetTrigger("jump");
		}
		else
		{
			animator.ResetTrigger("jump");
		}

		velocity.y += gravity * Time.deltaTime;

		if (velocity != Vector3.zero){
			animator.SetInteger("Walk", 1);
		}
		else{
			animator.SetInteger("Walk", 0);
		}

		charController.Move(velocity * Time.deltaTime);

	}

	void RotatePlayer()
	{
		//clamp to just rotate on y only camera and head only
		float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
		float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

		xRotation -= mouseY;
		xRotation = Mathf.Clamp(xRotation, -90f, 90f);

		Vector3 rotPlayer = transform.rotation.eulerAngles;
		rotPlayer.y += mouseX;

		transform.localRotation = Quaternion.Euler(0f, rotPlayer.y, 0f);
		transform.Rotate(Vector3.up * mouseX);

	}
}