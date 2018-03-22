using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System;
using UnityEngine;

public class Goal : MonoBehaviour {

	public bool Enabled;

	private HashSet<Trigger> allTriggers = new HashSet<Trigger>();
	private HashSet<Trigger> enabledTriggers = new HashSet<Trigger>();
	private GameController gameController;

	void Start() {
		gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();

		if (Enabled) {
			SetEnabled(Enabled);
		}
	}

	void OnTriggerEnter(Collider other) {
		if (!Enabled) {
			return;
		}
		Debug.Log("Hit at " + Time.time);
	}

	public void RegisterTrigger(Trigger trigger) {
		Conditions.Assert(!allTriggers.Contains(trigger), "Trying to register trigger, but trigger already registered");

		allTriggers.Add(trigger);
		if (trigger.Triggered) {
			enabledTriggers.Add(trigger);
		}
		SetEnabled(enabledTriggers.Count == allTriggers.Count());
	}

	public void Trigger(Trigger trigger) {
		Conditions.Assert(allTriggers.Contains(trigger), "Goal triggered by unknown trigger");

		if (!enabledTriggers.Remove(trigger)) {
			enabledTriggers.Add(trigger);
		}

		SetEnabled(enabledTriggers.Count == allTriggers.Count());
	}

	private void SetEnabled(Boolean enabled) {
		Enabled = enabled;

		Material m = GetComponentInChildren<Renderer>().material;
		m.SetFloat("_Animate", Enabled ? 1.0f : 0.0f);
	}
}
