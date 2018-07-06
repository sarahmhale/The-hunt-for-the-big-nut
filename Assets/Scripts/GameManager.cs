using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public int totalNrApples;
	public int currentApples;

	public int totalHealth = 1;
	private int currentHealth;

	public Text applesText;

	// Use this for initialization
	void Start () {
		currentHealth = totalHealth;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void reduceLife(int amountOfHealth){
		Debug.Log ("inHere");
		currentHealth -= amountOfHealth;
		if (currentHealth == 0) {
			Debug.Log("Dead");
		}
	}

	public void addApples(int nrOfApples){
		currentApples += nrOfApples;
		applesText.text = "Apples: " + currentApples + "/" + totalNrApples;
	}
}
