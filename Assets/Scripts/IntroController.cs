using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroController : MonoBehaviour {

	[SerializeField]
	private Text albertText;
	[SerializeField]
	private Text goHomeText;

	private float startTime;

	void Start() {
		albertText.gameObject.SetActive(false);
		goHomeText.gameObject.SetActive(false);
		startTime = Time.time;
	}

	void Update() {
		float time = Time.time - startTime;

		if (time >= 2.0f && time < 3.0f) {
			albertText.gameObject.SetActive(true);
			albertText.color = new Color(1.0f, 1.0f, 1.0f, 1.0f * (time - 2.0f));
		} else if (time >= 3.0f && time < 5.0f) {
			albertText.gameObject.SetActive(true);
			albertText.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
		} else if (time >= 5.0f && time < 6.0f) {
			albertText.gameObject.SetActive(true);
			albertText.color = new Color(1.0f, 1.0f, 1.0f, 1.0f * (1.0f - time + 5.0f));
		} else if (time >= 7.0f && time < 8.0f) {
			albertText.gameObject.SetActive(false);
			goHomeText.gameObject.SetActive(true);
			goHomeText.color = new Color(1.0f, 1.0f, 1.0f, 1.0f * (time - 7.0f));
		} else if (time >= 9.0f && time < 10.0f) {
			goHomeText.gameObject.SetActive(true);
			goHomeText.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
		} else if (time >= 10.0f && time < 11.0f) {
			goHomeText.gameObject.SetActive(true);
			goHomeText.color = new Color(1.0f, 1.0f, 1.0f, 1.0f * (1.0f - time + 10.0f));
		} else if (time >= 11.5f) {
			goHomeText.gameObject.SetActive(false);
			SceneManager.LoadScene("Level01");
		}
	}
}
