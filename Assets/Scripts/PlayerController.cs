using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

	public float moveSpeed;
	public Rigidbody rigidbody;
	public float jumpForce;

	// Use this for initialization
	void Start ()
	{
		rigidbody = GetComponent<Rigidbody> ();
	}
		
	// Update is called once per frame
	void Update ()
	{
		rigidbody.velocity = new Vector3 (
			Input.GetAxis ("Horizontal") * moveSpeed,
			rigidbody.velocity.y,
			Input.GetAxis ("Vertical") * moveSpeed);

		if(Input.GetButtonDown("Jump")){
			rigidbody.velocity = new Vector3 (
				rigidbody.velocity.x,
				jumpForce,
				rigidbody.velocity.z);
		}
	}
}
