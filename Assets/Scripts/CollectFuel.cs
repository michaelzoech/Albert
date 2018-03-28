using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectFuel : BetterMonoBehaviour {

	private GameController gameController;
	private AudioSource audioSource;

	void Start() {
		gameController = GetGameController();
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
