using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System;
using UnityEngine;

public class TriggerTarget : MonoBehaviour {

    public bool Enabled {
        get {
            return allTriggers.Count == enabledTriggers.Count;
        }
    }

    private HashSet<Trigger> allTriggers = new HashSet<Trigger>();
    private HashSet<Trigger> enabledTriggers = new HashSet<Trigger>();

    void OnTriggerEnter(Collider other) {
        if (!Enabled) {
            return;
        }
    }

    public void RegisterTrigger(Trigger trigger) {
        Conditions.Assert(!allTriggers.Contains(trigger), "Trying to register trigger, but trigger already registered");

        allTriggers.Add(trigger);
        if (trigger.Triggered) {
            enabledTriggers.Add(trigger);
        }
    }

    public void Trigger(Trigger trigger) {
        Conditions.Assert(allTriggers.Contains(trigger), "Goal triggered by unknown trigger");

        if (!enabledTriggers.Remove(trigger)) {
            enabledTriggers.Add(trigger);
        }
    }
}

