using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    [SerializeField]
    private GameObject target;
    [SerializeField]
    private Vector3 distance;
    [Range(0.0f, 1.0f), SerializeField]
    private float follow = 0.2f;

    void Start() {
        transform.position = target.transform.position + distance;
    }

    void Update() {
        Vector3 wantedPosition = target.transform.position + distance;
        transform.position = Vector3.Lerp(transform.position, wantedPosition, follow);
    }
}
