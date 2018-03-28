using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameObjectExtensions {

    public static T GetComponentOrThrow<T>(this GameObject self) {
        T component = self.GetComponent<T>();
        Conditions.NotNull(component);
        return component;
    }
}