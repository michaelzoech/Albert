using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectFuel : MonoBehaviour {

	private GameController gameController;

	void Start() {
		GameObject gameControllerObject = GameObject.FindWithTag("GameController");
		gameController = gameControllerObject.GetComponent<GameController>();
	}

	void OnTriggerEnter(Collider other) {
		Destroy(gameObject);
		gameController.OnFuelCollected();
	}
}
