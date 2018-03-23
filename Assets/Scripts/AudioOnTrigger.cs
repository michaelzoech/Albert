using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioOnTrigger : MonoBehaviour {

	new private AudioSource audio;
	private Trigger trigger;

	private bool played;

	void Start () {
		audio = GetComponent<AudioSource>();
		trigger = GetComponent<Trigger>();
		played = trigger.Triggered;
	}
	
	void Update () {
		if (trigger.Triggered && !played) {
			audio.Play();
			played = true;
		} else if (!trigger.Triggered && played) {
			played = false;
		}
	}
}
