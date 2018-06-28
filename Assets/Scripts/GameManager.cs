using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public int TotalNrApples;
	public int currentApples;
	public Text applesText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void addApples(int nrOfApples){
		this.currentApples += nrOfApples;
		applesText.text = "Apples: " + currentApples + "/" + TotalNrApples;
	}
}
