using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject Object;
    public Vector3 Distance;
    public float Follow = 0.2f;

    void Start() {
    }

    void Update() {
        Vector3 wantedPosition = Object.transform.position + Distance;
        transform.position = Vector3.Lerp(transform.position, wantedPosition, Follow);
    }
}
