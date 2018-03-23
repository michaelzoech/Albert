using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour {

	public TriggerTarget Target;
	public Trigger[] Disable;
	public Trigger[] Enable;
	public bool Triggered;

	private float initialScaleY;
	private bool inTriggerRecursion;

	void Start() {
		initialScaleY = transform.localScale.y;
		if (Target != null) {
			Target.RegisterTrigger(this);
		}
	}

	void OnTriggerEnter(Collider other) {
		if (Triggered) {
			return;
		}

		if (other.tag == "Player") {
			UpdateTriggerState(true);
		}
	}

	void UpdateTriggerState(bool newState) {
		Conditions.Assert(!(inTriggerRecursion & newState), "Recursion in trigger, backing out");
		inTriggerRecursion = true;

		Triggered = newState;

		Vector3 scale  = transform.localScale;
		scale.y = Triggered ? initialScaleY / 5.0f : initialScaleY;
		transform.localScale = scale;

		if (Target != null) {
			Target.Trigger(this);
		}

		if (Triggered && Disable != null) {
			foreach (Trigger trigger in Disable) {
				trigger.UpdateTriggerState(false);
			}
		}

		if (Triggered && Enable != null) {
			foreach (Trigger trigger in Enable) {
				trigger.UpdateTriggerState(true);
			}
		}

		inTriggerRecursion = false;
	}
}
