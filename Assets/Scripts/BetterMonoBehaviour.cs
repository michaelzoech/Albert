using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterMonoBehaviour : MonoBehaviour {

    public GameController GetGameController() {
        return GetGameObjectWithTag("GameController").GetComponentOrThrow<GameController>();
    }

    public GameObject GetPlayerGameObject() {
        return GetGameObjectWithTag("Player");
    }

    public PlayerInput GetPlayerInput() {
        return GameObject.FindGameObjectWithTag("GameController").GetComponentOrThrow<PlayerInput>();
    }

    public GameObject GetGameObjectWithTag(string tag) {
        GameObject obj = GameObject.FindGameObjectWithTag(tag);
        Conditions.NotNull(obj);
        return obj;
    }

    public T GetComponentOrThrow<T>() {
        T component = GetComponent<T>();
        Conditions.NotNull(component);
        return component;
    }
}
