using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	//Position of the object in the world
	public Transform target;
	//How far from the player
	public Vector3 offset;
	public float rotateSpeed;
	// Use this for initialization
	void Start () {
		offset = target.position -transform.position;
	}

	void rotateTarget ()
	{
		float horizontal = Input.GetAxis ("Mouse X") * rotateSpeed;
		//float vertical = -(Input.GetAxis ("Mouse Y") * rotateSpeed);
		target.Rotate (0, horizontal, 0);
	}	

		
	// Update is called once per frame
	void Update () {
		rotateTarget ();
		Quaternion rotation = Quaternion.Euler (target.eulerAngles.x,target.eulerAngles.y,0);
		transform.position = target.position - (rotation * offset);
		transform.LookAt (target);
		
	}
}
