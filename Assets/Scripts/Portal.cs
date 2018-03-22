using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {

	public GameObject target;

	// Optional trigger
	private Trigger trigger;

	void Start () {
		trigger = GetComponent<Trigger>();
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag != "Player") {
			return;
		}

		if (trigger != null && !trigger.Triggered) {
			return;
		}

		Vector3 d = other.gameObject.transform.position - gameObject.transform.position;

		other.gameObject.transform.position = target.transform.position + new Vector3(0.0f, d.y, 0.0f);
	}
}
