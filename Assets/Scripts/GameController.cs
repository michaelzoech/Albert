using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    [SerializeField]
    private AudioClip gameOverAudio;
    [SerializeField]
    private Text ScoreText;

    private AudioSource audioSource;
    private SceneFade sceneFade;
    private int fuelCollected;
    private bool isGameOver;

    void Start () {
        fuelCollected = 0;
        audioSource = GetComponent<AudioSource>();
        sceneFade = GetComponent<SceneFade>();
        sceneFade.StartFade(SceneFade.Direction.In);
    }

    void Update() {
    }

    public void OnFuelCollected() {
        fuelCollected++;
        ScoreText.text = "Score: " + fuelCollected;
    }

    public void GameOver() {
        if (isGameOver) {
            return;
        }
        isGameOver = true;
        StartCoroutine(LoadLevel());
    }

    private IEnumerator LoadLevel() {
        audioSource.PlayOneShot(gameOverAudio);
        yield return new WaitForSeconds(gameOverAudio.length);
        sceneFade.StartFade(SceneFade.Direction.Out);
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
