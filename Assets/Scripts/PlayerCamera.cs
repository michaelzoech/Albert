using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : BetterMonoBehaviour {

    [SerializeField]
    private Vector3 distance;
    [Range(0.0f, 1.0f), SerializeField]
    private float follow = 0.2f;

    private GameObject player;

    void Start() {
        player = GetPlayerGameObject();
        transform.position = player.transform.position + distance;
    }

    void Update() {
        Vector3 wantedPosition = player.transform.position + distance;
        transform.position = Vector3.Lerp(transform.position, wantedPosition, follow);
    }
}
