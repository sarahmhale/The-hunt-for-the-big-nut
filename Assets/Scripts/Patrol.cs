using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour {
	public Transform[] patrolPoints;
	public float moveSpeed;

	private int currentPointIndex = 0;
	// Use this for initialization
	void Start () {
		transform.position = patrolPoints [0].position;
	}
	
	// Update is called once per frame
	void Update () {

		if (transform.position == patrolPoints [currentPointIndex].position) {
			currentPointIndex++;
			if (currentPointIndex == patrolPoints.Length) {
				currentPointIndex = 0;
			}
		}

		transform.position = Vector3.MoveTowards (
			transform.position,
			patrolPoints [currentPointIndex].position,
			moveSpeed * Time.deltaTime
		);
		
	}
}
