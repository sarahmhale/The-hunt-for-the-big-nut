using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour {
	public int totalNrApples;
	public int currentApples;


	private bool gameHasEnded = false;
	public float restartDelay = 2f;

	public GameObject bigApple;

	public Text applesText;

	// Use this for initialization
	void Start () {
		bigApple.SetActive (false);
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

	public void addApples(int nrOfApples){
		currentApples += nrOfApples;
		applesText.text = "Apples: " + currentApples + "/" + totalNrApples;
		if (currentApples == totalNrApples) {
			bigApple.SetActive (true);
		}

		if (currentApples > totalNrApples) {
			endGame ();
		}
	}
}
