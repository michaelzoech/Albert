using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour {

	private bool triggered;

	void Start() {
		triggered = false;
	}

	void OnTriggerEnter(Collider other) {
		if (triggered) {
			return;
		}
		if (other.tag == "Player") {
			Vector3 scale = transform.localScale;
			scale.y = 0.05f;
			transform.localScale = scale;
			triggered = true;
		}
	}
}
