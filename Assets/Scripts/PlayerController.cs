using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float speed = 6.0F;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;
	private Vector3 moveDirection = Vector3.zero;
	public Animator animator;
	private CharacterController controller;


	// Use this for initialization
	void Start ()
	{
		controller = GetComponent<CharacterController>();
	}
	void animate()
	{
		animator.SetBool ("grounded", controller.isGrounded);
		animator.SetFloat("speed", (Mathf.Abs(Input.GetAxis ("Vertical"))));
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Enemy") {
			this.enabled = false;
			animator.SetBool ("dead",true);
			FindObjectOfType<GameManager> ().endGame ();
		}
	}

	void rotate()
	{
		Vector3 facingrotation = Vector3.Normalize(
			new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"))
		);
		if (facingrotation != Vector3.zero)        
			transform.forward = facingrotation;
	}

	void jump()
	{
		if (Input.GetButton ("Jump")) {
			moveDirection.y = jumpSpeed;
		}
	}

	void move()
	{
		if (controller.isGrounded) {
			moveDirection = new Vector3(Input.GetAxis("Horizontal"),0, Input.GetAxis("Vertical"));
			moveDirection *= speed;
			jump ();
		}

		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
	}
	// Update is called once per frame
	void Update ()
	{
		move ();
		animate ();
		rotate ();
		if (transform.position.y < -1f)
		{
			FindObjectOfType<GameManager> ().endGame ();
		}

	}

}
