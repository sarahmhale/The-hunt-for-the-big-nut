using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public Transform target;
	public Vector3 offset;
	public float rotateSpeed;
	public Transform pivot;

	void Start () {
		offset = target.position -transform.position;
		pivot.position = target.position;
		pivot.parent = target;
		Cursor.lockState = CursorLockMode.Locked;
	}

	void rotatePivot ()
	{
		float vertical = -(Input.GetAxis ("Mouse Y") * rotateSpeed);
		pivot.Rotate (vertical, 0, 0);
	}

	void rotateTarget ()
	{
		float horizontal = Input.GetAxis ("Mouse X") * rotateSpeed;
		target.Rotate (0, horizontal, 0);
	}

	void rotateCamera ()
	{
		Quaternion rotation = Quaternion.Euler (pivot.eulerAngles.x,target.eulerAngles.y,0);
		transform.position = target.position - (rotation * offset);
		transform.LookAt (target);
	}
	void LateUpdate () {
		rotateTarget ();
		//rotatePivot ();
		rotateCamera ();
	}
}
