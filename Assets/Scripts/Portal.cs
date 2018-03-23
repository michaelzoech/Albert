using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {

	public GameObject target;

	private TriggerTarget triggerTarget;
	private bool previousEnabled;

	void Start () {
		triggerTarget = GetComponent<TriggerTarget>();
		if (triggerTarget == null) {
			SetEnabled(true);
		}
	}

	void Update() {
		if (triggerTarget != null && previousEnabled != triggerTarget.Enabled) {
			SetEnabled(triggerTarget.Enabled);
			previousEnabled = triggerTarget.Enabled;
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag != "Player") {
			return;
		}

		if (triggerTarget != null && !triggerTarget.Enabled) {
			return;
		}

		Vector3 d = other.gameObject.transform.position - gameObject.transform.position;
		other.gameObject.transform.position = target.transform.position + new Vector3(0.0f, d.y, 0.0f);
	}

	private void SetEnabled(bool enabled) {
		Material m = GetComponentInChildren<Renderer>().material;
		m.SetFloat("_Animate", enabled ? 1.0f : 0.0f);
	}
}
