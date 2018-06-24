using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

	public float moveSpeed;
	public float jumpForce;
	public float gravityScale;
	public CharacterController characterController;
	private Vector3 moveDirection;

	// Use this for initialization
	void Start ()
	{
		characterController = GetComponent<CharacterController> ();
	}

	void jump(){
		moveDirection.y = 0f;
		if(Input.GetButtonDown ("Jump")){
			moveDirection.y = jumpForce;	
		}
	}
		
	// Update is called once per frame
	void Update ()
	{

		moveDirection = (transform.forward * Input.GetAxis ("Vertical")*moveSpeed);

		if (characterController.isGrounded) {
			jump (); 
		}

		moveDirection.y = moveDirection.y + (gravityScale * Physics.gravity.y* Time.deltaTime);
		characterController.Move (moveDirection * Time.deltaTime);
	}
}
