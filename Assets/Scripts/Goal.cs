using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {

	private GameController gameController;

	void Start() {
		gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
	}

	void OnTriggerEnter(Collider other) {
		Debug.Log("Hit");
	}
}
