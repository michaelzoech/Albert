using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleOnTrigger : MonoBehaviour {

    public float scaleBy = 2.0f;

    private Trigger trigger;
    private float scaleOn;
    private float scaleOff;

    void Start() {
        trigger = GetComponent<Trigger>();
        scaleOff = transform.localScale.y;
        scaleOn = scaleOff / scaleBy;
        UpdateScale();
    }

    void Update() {
        UpdateScale();
    }

    void UpdateScale() {
        Vector3 scale = transform.localScale;
        float expectedScale = trigger.Triggered ? scaleOn : scaleOff;
        if (scale.y != expectedScale) {
            scale.y = expectedScale;
            transform.localScale = scale;
        }
    }
}