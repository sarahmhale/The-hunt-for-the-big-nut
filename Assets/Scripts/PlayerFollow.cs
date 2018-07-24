using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour {

	public Transform PlayerTransform;

	private Vector3 cameraOffset;
	[Range(0.01f, 1.0f)]
	public float smooth = 0.5f;

	// Use this for initialization
	void Start () 
	{
		cameraOffset = transform.position - PlayerTransform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 newPosition = PlayerTransform.position + cameraOffset;
		transform.position = Vector3.Slerp (transform.position, newPosition, smooth);
	}
}
