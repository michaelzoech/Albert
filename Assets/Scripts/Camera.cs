using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

    public GameObject Object;
    public Vector3 Distance;
    public float Follow = 0.2f;

    private Vector3 initialDistance;

    void Start() {
        initialDistance = transform.position - Object.transform.position;
    }

    void Update() {
        Vector3 wantedPosition = Object.transform.position + Distance;
        transform.position = Vector3.Lerp(transform.position, wantedPosition, Follow);
    }
}
