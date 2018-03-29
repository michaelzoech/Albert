using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : BetterMonoBehaviour {

    private enum Direction {
        Forward,
        Left,
        Right,
        Backward
    }

    [SerializeField]
    private LayerMask ground;

    [SerializeField]
    private float  speed = 3.0f;
    [SerializeField]
    private bool allowLeftTurn = true;
    [SerializeField]
    private bool allowRightTurn = true;
    [SerializeField]
    private bool allowBackwardTurn = true;

    private GameController gameController;

    private float lastDecisionMade = 0.0f;

    void Start () {
        gameController = GetGameController();
        lastDecisionMade = Time.time;
    }

    void Update () {
        Vector3 pos = transform.position + new Vector3(0.0f, 0.2f, 0.0f);
        Vector3 forward = Vector3.Normalize(transform.forward);
        float moveLength = 0.6f + (transform.forward * (Time.deltaTime * speed)).magnitude * 1.1f;
        bool canMoveForward = !Physics.Raycast(pos - transform.right * 0.4f, forward, moveLength, ground) && !Physics.Raycast(pos + transform.right * 0.4f, forward, moveLength, ground);
        bool canMoveLeft = !Physics.Raycast(pos + forward * 0.4f, -transform.right, 1.5f, ground) && !Physics.Raycast(pos - forward * 0.4f, -transform.right, 1.5f, ground);
        bool canMoveRight = !Physics.Raycast(pos + forward * 0.4f, transform.right, 1.5f, ground) && !Physics.Raycast(pos - forward * 0.4f, transform.right, 1.5f, ground);

        if (lastDecisionMade + 20.0f < Time.time || !canMoveForward) {
            List<Direction> directions = new List<Direction>();

            if (canMoveForward) {
                directions.Add(Direction.Forward);
            } else if (allowBackwardTurn && !canMoveLeft && !canMoveRight) {
                directions.Add(Direction.Backward);
            }
            if (allowLeftTurn && canMoveLeft) {
                directions.Add(Direction.Left);
            }
            if (allowRightTurn && canMoveRight) {
                directions.Add(Direction.Right);
            }

            if (directions.Count == 0) {
                return;
            }

            int index = Random.Range(0, directions.Count);

            switch (directions[index]) {
                case Direction.Forward:
                    break;
                case Direction.Backward:
                    transform.Rotate(0.0f, 180.0f, 0.0f);
                    break;
                case Direction.Left:
                    transform.Rotate(0.0f, -90.0f, 0.0f);
                    break;
                case Direction.Right:
                    transform.Rotate(0.0f, 90.0f, 0.0f);
                    break;
            }

            lastDecisionMade = Time.time;
        }

        forward = transform.forward * (Time.deltaTime * speed);

        transform.position = transform.position + forward;
    }

    void OnTriggerEnter(Collider other) {
        if (other.IsPlayer()) {
            gameController.GameOver();
        }
    }
}
