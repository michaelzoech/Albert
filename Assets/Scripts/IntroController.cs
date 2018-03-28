using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroController : MonoBehaviour {

    private Coroutine WaitRoutine;

    void Start() {
        WaitRoutine = StartCoroutine(WaitForIntroToEnd());
    }

    void Update() {
        if (Input.GetButtonDown("Jump") || Input.GetButtonDown("Fire1") || Input.GetMouseButtonDown(0)) {
            StopCoroutine(WaitRoutine);
            LoadLevel();
        }
    }

    IEnumerator WaitForIntroToEnd() {
        yield return new WaitForSeconds(11.0f);
        LoadLevel();
    }

    private void LoadLevel() {
        SceneManager.LoadScene("Level01");
    }
}
