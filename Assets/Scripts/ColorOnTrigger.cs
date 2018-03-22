using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorOnTrigger : MonoBehaviour {

    public Color on;
    public Color off;

    private Trigger trigger;
    private Material material;

    void Start() {
        trigger = GetComponent<Trigger>();
        material = GetComponentInChildren<Renderer>().material;
        UpdateColor();
    }

    void Update() {
        UpdateColor();
    }

    void UpdateColor() {
        int colorPropertyId = Shader.PropertyToID("_Color");
        if (trigger.Triggered && material.GetColor(colorPropertyId) != on) {
            material.SetColor(colorPropertyId, on);
        } else if (!trigger.Triggered && material.GetColor(colorPropertyId) != off) {
            material.SetColor(colorPropertyId, off);
        }
    }
}