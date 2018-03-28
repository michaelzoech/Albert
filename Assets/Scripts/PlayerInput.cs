using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

    public bool Jump { get; private set; }
    public float HorizontalMovement { get; private set; }
    public float VerticalMovement {get; private set; }
    public bool Dash { get; private set; }
    public bool ToggleDebugPanel { get; private set; }

    void Update() {
        Dash = Input.GetButtonDown("Fire3");
        Jump = Input.GetButtonDown("Jump") || Input.GetButtonDown("Fire1");
        HorizontalMovement = Input.GetAxis("Horizontal");
        VerticalMovement = Input.GetAxis("Vertical");
        ToggleDebugPanel = Input.GetKeyDown(KeyCode.F1);
    }
}
