using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hud : BetterMonoBehaviour {

    [SerializeField]
    private Text scoreText;

    private GameController gameController;
    private GameController.OnScoreChanged onScoreChanged;

    void Start () {
        onScoreChanged += (oldScore, newScore) => {
            scoreText.text = "Score: " + newScore;
        };

        gameController = GetGameController();
        gameController.OnScoreChangedEvent += onScoreChanged;
    }
    
    void Update () {
        
    }

    void OnDestroy() {
        gameController.OnScoreChangedEvent -= onScoreChanged;
    }
}
