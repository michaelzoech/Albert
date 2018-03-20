using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public Text ScoreText;

	private int fuelCollected;

	void Start () {
		fuelCollected = 0;
	}

	public void OnFuelCollected() {
		fuelCollected++;
		ScoreText.text = "Score: " + fuelCollected;
	}
}
