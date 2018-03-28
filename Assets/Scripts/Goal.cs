using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : BetterMonoBehaviour {

    private TriggerTarget triggerTarget;

    private bool previousEnabled;

    void Start() {
        triggerTarget = GetComponent<TriggerTarget>();
    }

    void Update() {
        if (triggerTarget != null && previousEnabled != triggerTarget.Enabled) {
            SetEnabled(triggerTarget.Enabled);
            previousEnabled = triggerTarget.Enabled;
        }
    }

    void OnTriggerEnter(Collider other) {
        if (triggerTarget != null && !triggerTarget.Enabled) {
            return;
        }
        GetGameController().LevelCompleted();
    }

    private void SetEnabled(bool enabled) {
        Material m = GetComponentInChildren<Renderer>().material;
        m.SetFloat("_Animate", enabled ? 1.0f : 0.0f);
    }
}
