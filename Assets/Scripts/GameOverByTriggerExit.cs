using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverByTriggerExit : BetterMonoBehaviour {

    private GameController gameController;

    void Start() {
        gameController = GetGameController();
    }

    void OnTriggerExit (Collider other) {
        gameController.GameOver();	
    }
}
