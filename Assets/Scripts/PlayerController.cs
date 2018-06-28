using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

	public float moveSpeed;
	public float jumpForce;
	public float gravityScale;
	private CharacterController characterController;
	private Vector3 moveDirection;
	public Animator animator;

	public float rotateSpeed;
	public Transform pivot;



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
		
	void applyMovement(){
		moveDirection.y = moveDirection.y + (gravityScale * Physics.gravity.y* Time.deltaTime);
		characterController.Move (moveDirection * Time.deltaTime);
	}

	void animate(){
		animator.SetBool ("grounded", characterController.isGrounded);
		animator.SetFloat("speed", (Mathf.Abs(Input.GetAxis ("Vertical"))));
	}
		
//	void rotatePlayer(){
//		if(Input.GetAxis ("Vertical")!= 0|| Input.GetAxis("Horizontal")!= 0){
//			transform.rotation = Quaternion.Euler (0f, 0f,pivot.rotation.eulerAngles.z);
//		}
//	}
	// Update is called once per frame
	void Update ()
	{
		float yStore = moveDirection.y;
		moveDirection = (transform.forward * Input.GetAxis ("Vertical"))+
			(transform.right * Input.GetAxis("Horizontal"));
		moveDirection = moveDirection.normalized * moveSpeed;
		moveDirection.y = yStore;

		if (characterController.isGrounded) {
			jump (); 
		}


		applyMovement ();
		//rotatePlayer();
		animate ();
	

	}
}
