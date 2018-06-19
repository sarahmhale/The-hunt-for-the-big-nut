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
		
	// Update is called once per frame
	void Update ()
	{

		moveDirection = new Vector3 (
			Input.GetAxis ("Horizontal") * moveSpeed,
			moveDirection.y,
			Input.GetAxis ("Vertical") * moveSpeed);
		
		if (characterController.isGrounded && Input.GetButtonDown ("Jump")) {
			moveDirection.y = jumpForce;	
		}

		moveDirection.y = moveDirection.y + (gravityScale * Physics.gravity.y* Time.deltaTime);
		characterController.Move (moveDirection * Time.deltaTime);
	}
}
