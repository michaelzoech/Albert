using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public delegate void OnScoreChanged(int oldScore, int newScore);

    public event OnScoreChanged OnScoreChangedEvent;

    [SerializeField]
    private AudioClip gameOverAudio;

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
        OnScoreChangedEvent.Invoke(fuelCollected-1, fuelCollected);
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
