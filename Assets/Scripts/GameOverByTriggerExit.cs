using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverByTriggerExit : MonoBehaviour {

	private GameController gameController;

	void Start() {
		gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
	}

	void OnTriggerExit (Collider other) {
		gameController.GameOver();	
	}
}
