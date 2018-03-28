using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour {

    public bool Triggered { get { return triggered; } }

    [SerializeField]
    private TriggerTarget[] target;
    [SerializeField]
    private Trigger[] disable;
    [SerializeField]
    private Trigger[] enable;
    [SerializeField]
    private bool triggered;

    private float initialScaleY;
    private bool inTriggerRecursion;

    void Start() {
        initialScaleY = transform.localScale.y;
        foreach (TriggerTarget trigger in target) {
            trigger.RegisterTrigger(this);
        }
    }

    void OnTriggerEnter(Collider other) {
        if (triggered) {
            return;
        }

        if (other.IsPlayer()) {
            UpdateTriggerState(true);
        }
    }

    void UpdateTriggerState(bool newState) {
        Conditions.Assert(!(inTriggerRecursion & newState), "Recursion in trigger, backing out");
        inTriggerRecursion = true;

        triggered = newState;

        Vector3 scale  = transform.localScale;
        scale.y = triggered ? initialScaleY / 5.0f : initialScaleY;
        transform.localScale = scale;

        foreach (TriggerTarget trigger in target) {
            trigger.Trigger(this);
        }

        if (triggered && disable != null) {
            foreach (Trigger trigger in disable) {
                trigger.UpdateTriggerState(false);
            }
        }

        if (triggered && enable != null) {
            foreach (Trigger trigger in enable) {
                trigger.UpdateTriggerState(true);
            }
        }

        inTriggerRecursion = false;
    }
}
