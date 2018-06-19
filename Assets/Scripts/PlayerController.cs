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
			0f,
			Input.GetAxis ("Vertical") * moveSpeed);

		if (Input.GetButtonDown ("Jump")) {
			moveDirection.y = jumpForce;
		}
		moveDirection.y = moveDirection.y + (gravityScale* Physics.gravity.y);
		characterController.Move (moveDirection * Time.deltaTime);
	}
}
