using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    [SerializeField]
    private AudioClip gameOverAudio;
    public Text ScoreText;

    public GameObject debugPanel;

    private AudioSource audioSource;
    private int fuelCollected;
    private bool isGameOver;

    void Start () {
        fuelCollected = 0;
        audioSource = GetComponent<AudioSource>();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.F1)) {
            debugPanel.SetActive(!debugPanel.activeSelf);
        }
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
        yield return new WaitForSeconds(gameOverAudio.length + 1.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
