using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterMonoBehaviour : MonoBehaviour {

    public GameController GetGameController() {
        return GameObject.FindGameObjectWithTag("GameController").GetComponentOrThrow<GameController>();
    }

    public PlayerInput GetPlayerInput() {
        return GameObject.FindGameObjectWithTag("GameController").GetComponentOrThrow<PlayerInput>();
    }

    public T GetComponentOrThrow<T>() {
        T component = GetComponent<T>();
        Conditions.NotNull(component);
        return component;
    }
}
