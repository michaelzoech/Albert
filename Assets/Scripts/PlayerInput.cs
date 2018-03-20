﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

    public bool Jump { get; private set; }
    public float HorizontalMovement { get; private set; }
    public float VerticalMovement {get; private set; }
    public bool Dash { get; private set; }

    void Update() {
        Dash = Input.GetButtonDown("Fire3");
        Jump = Input.GetButtonDown("Jump");
        HorizontalMovement = Input.GetAxis("Horizontal");
        VerticalMovement = Input.GetAxis("Vertical");
    }
}
