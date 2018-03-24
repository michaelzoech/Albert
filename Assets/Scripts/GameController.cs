using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public Text ScoreText;

	public GameObject debugPanel;

	private int fuelCollected;

	void Start () {
		fuelCollected = 0;
	}

	void Update() {
		if (Input.GetKeyDown(KeyCode.F1)) {
			debugPanel.SetActive(!debugPanel.activeSelf);
		}
	}

	public void OnFuelCollected() {
		fuelCollected++;
		ScoreText.text = "Score: " + fuelCollected;
	}

	public void GameOver() {
		SceneManager.LoadScene("Level01");
	}
}
