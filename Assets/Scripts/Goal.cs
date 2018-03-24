using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour {

	private TriggerTarget triggerTarget;
	private GameController gameController;

	private bool previousEnabled;

	void Start() {
		gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
		triggerTarget = GetComponent<TriggerTarget>();
	}

	void Update() {
		if (triggerTarget != null && previousEnabled != triggerTarget.Enabled) {
			SetEnabled(triggerTarget.Enabled);
			previousEnabled = triggerTarget.Enabled;
		}
	}

	void OnTriggerEnter(Collider other) {
		if (triggerTarget != null && !triggerTarget.Enabled) {
			return;
		}
		SceneManager.LoadScene("Outro");
	}

	private void SetEnabled(bool enabled) {
		Material m = GetComponentInChildren<Renderer>().material;
		m.SetFloat("_Animate", enabled ? 1.0f : 0.0f);
	}
}
