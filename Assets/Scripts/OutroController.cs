using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OutroController : MonoBehaviour {

	[SerializeField]
	private Text theEndText;

	private float startTime;

	void Start () {
		theEndText.gameObject.SetActive(false);
		startTime = Time.time;
	}
	
	void Update () {
		float time = Time.time - startTime;

		if (time >= 1.0f && time < 2.0f) {
			theEndText.gameObject.SetActive(true);
			theEndText.color = new Color(1.0f, 1.0f, 1.0f, 1.0f * (time - 1.0f));
		} else if (time >= 2.0f && time < 4.0f) {
			theEndText.gameObject.SetActive(true);
			theEndText.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
		} else if (time >= 4.0f && time < 7.0f) {
			theEndText.gameObject.SetActive(true);
			theEndText.color = new Color(1.0f, 1.0f, 1.0f, 1.0f * (1.0f - time + 4.0f ));
		} else if (time >= 7.0f && time < 8.0f) {
			theEndText.gameObject.SetActive(false);
		} else if (time >= 8.0f) {
			Application.Quit();
		}
	}
}
