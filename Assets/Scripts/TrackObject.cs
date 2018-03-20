using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackObject : MonoBehaviour {

    public GameObject Object;

    private Vector3 distance;

    void Start() {
        distance = Object.transform.position - transform.position;
    }

    void Update() {
        transform.position = Object.transform.position - distance;
    }
}
