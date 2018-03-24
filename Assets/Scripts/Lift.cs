using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour {

    private enum State {
        Down,
        MovingUp,
        Up,
        MovingDown,
    }

    private const float moveBySecond = 1.0f;

    [SerializeField]
    float moveUpBy;
    [SerializeField]
    float pause;

    private float initialY;
    private State state;
    private float lastStateChangeTime;
    private TriggerTarget triggerTarget;
    private GameController gameController;

    void Start () {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        triggerTarget = GetComponent<TriggerTarget>();
        initialY = transform.position.y;
        state = State.Down;
        lastStateChangeTime = Time.time;
    }
    
    void Update () {
        if (triggerTarget != null && !triggerTarget.Enabled) {
            return;
        }
        switch (state) {
            case State.Down:
                if (lastStateChangeTime + pause < Time.time) {
                    state = State.MovingUp;
                    lastStateChangeTime = Time.time;
                }
                break;
            case State.Up:
                if (lastStateChangeTime + pause < Time.time) {
                    state = State.MovingDown;
                    lastStateChangeTime = Time.time;
                }
                break;
            case State.MovingUp:
                if (transform.position.y < initialY + moveUpBy) {
                    Vector3 pos = transform.position;
                    pos.y = Mathf.Min(transform.position.y + moveBySecond * Time.deltaTime, initialY + moveUpBy);
                    transform.position = pos;
                } else {
                    state = State.Up;
                }
                break;
            case State.MovingDown:
                if (transform.position.y > initialY) {
                    Vector3 pos = transform.position;
                    pos.y = Mathf.Max(transform.position.y - moveBySecond * Time.deltaTime, initialY);
                    transform.position = pos;
                } else {
                    state = State.Down;
                }
                break;
        }
    }

    void OnCollisionEnter(Collision collision) {
        Debug.Log("Is called now with new character controller, we can remove trigger collider");
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag != "Player") {
            return;
        }

        float distUp = Mathf.Abs(transform.position.y - other.bounds.max.y);
        float distDown = Mathf.Abs(transform.position.y - other.bounds.min.y);

        if (distUp < distDown && state == State.MovingDown) {
            state = State.Down;
            gameController.GameOver();
        }
    }
}
