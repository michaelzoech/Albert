using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExtroController : MonoBehaviour {

    [SerializeField]
    private float waitTime;

    [SerializeField]
    private string nextScene;

    private Coroutine WaitRoutine;

    void Start() {
        WaitRoutine = StartCoroutine(WaitForEnd());
    }

    void Update() {
        if (Input.GetButtonDown("Jump") || Input.GetButtonDown("Fire1") || Input.GetMouseButtonDown(0)) {
            StopCoroutine(WaitRoutine);
            NextScene();
        }
    }

    IEnumerator WaitForEnd() {
        yield return new WaitForSeconds(waitTime);
        NextScene();
    }

    private void NextScene() {
        if (nextScene != "") {
            SceneManager.LoadScene(nextScene);
        } else {
            Application.Quit();
        }
    }
}
