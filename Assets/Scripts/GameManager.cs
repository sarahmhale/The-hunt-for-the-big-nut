using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour {
	public int totalNrApples;
	public int currentApples;

	public int totalHealth = 1;
	private int currentHealth;
	private bool gameHasEnded = false;
	public float restartDelay = 2f;

	public Text applesText;

	// Use this for initialization
	void Start () {
		currentHealth = totalHealth;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void restartGame(){
		gameHasEnded = false;
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);

	}

	public void endGame(){

		if (gameHasEnded == false) {
			gameHasEnded = true;
			Debug.Log ("Game Over");
			Invoke ("restartGame", restartDelay);
		}

	}
	public void reduceLife(int amountOfHealth){
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
