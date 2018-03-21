using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimRotator : MonoBehaviour {

	private Vector3 rotation;

	void Start() {
		rotation = transform.rotation.eulerAngles;
	}

	void Update() {
		rotation.y += 200.0f * Time.deltaTime;
		if (rotation.y > 360.0f) {
			rotation.y -= 360.0f;
		}
	}

	void LateUpdate () {
		transform.rotation = Quaternion.Euler(rotation);
	}
}
