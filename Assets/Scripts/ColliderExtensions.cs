using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ColliderExtensions {

    public static bool IsPlayer(this Collider self) {
        return self.tag == "Player";
    }
}