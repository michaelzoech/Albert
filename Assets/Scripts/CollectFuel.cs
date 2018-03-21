using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectFuel : MonoBehaviour {

	private GameController gameController;
	private AudioSource audioSource;

	void Start() {
		GameObject gameControllerObject = GameObject.FindWithTag("GameController");
		gameController = gameControllerObject.GetComponent<GameController>();
		audioSource = GetComponent<AudioSource>();
	}

	void OnTriggerEnter(Collider other) {
		gameController.OnFuelCollected();
		audioSource.Play();
		GetComponent<Renderer>().enabled = false;
		GetComponent<Collider>().enabled = false;
		Destroy(gameObject, audioSource.clip.length);
	}
}
