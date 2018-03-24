using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private const float JumpHeight = 1.0f;
    private const float MoveSpeed = 15.0f;
    private const float DashDistance = 2.0f;

    public bool DeathOnFall { get { return deathOnFall; } set { deathOnFall = value; } }

    [SerializeField]
    private LayerMask ground;
    [SerializeField]
    private float gravity;
    [SerializeField]
    private Vector3 drag;
    [SerializeField]
    private bool deathOnFall = true;

    private GameController gameController;
    private CharacterController characterController;
    private PlayerInput playerInput;
    private Vector3 velocity;
    private float lastHeightGrounded;

    void Start() {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        characterController = GetComponent<CharacterController>();
        //characterController.enableOverlapRecovery = true;
        //characterController.detectCollisions = true;
        playerInput = GetComponent<PlayerInput>();
        velocity = new Vector3();
    }

    void Update() {
        velocity = characterController.velocity;

        if (characterController.isGrounded) {
            velocity.y = 0.0f;
            lastHeightGrounded = transform.position.y;
        }

        if (deathOnFall && lastHeightGrounded > transform.position.y + 4.5f) {
            gameController.GameOver();
        }

        Vector3 move = new Vector3(playerInput.HorizontalMovement, 0.0f, playerInput.VerticalMovement);
        Quaternion q = Quaternion.Euler(0.0f, -45.0f, 0.0f);
        move = q * move;
        //characterController.Move(move * MoveSpeed * Time.deltaTime);
        velocity += move * MoveSpeed * Time.deltaTime;
        if (move != Vector3.zero) {
            transform.forward = move;
        }

        Ray downRay = new Ray(transform.position, Vector3.down);
        float maxDistance = 4f;
        RaycastHit hit;
        float moveDrag = 0.0f;

        if (Physics.Raycast(downRay, out hit, maxDistance, ground)) {
            if (hit.normal.y < 0.95f) {
                // We are on a slope, lets see if we are moving down or up
                Vector3 dir = velocity.normalized;
                dir.y = 0.0f;
                dir.Normalize();

                float d = Vector3.Dot(dir, hit.normal);

                if (d <= 0.0f) {
                    moveDrag = Mathf.Abs(d) * 5.0f;
                } else {
                    // Needs to be relative to vel dot direction down vector, same for up?
                    // E.g. moving across a slope
                    velocity += 2.0f * velocity * Time.deltaTime;
                }
            }
        }

        if (playerInput.Jump && characterController.isGrounded) {
            velocity.y += Mathf.Sqrt(JumpHeight * -2f * gravity);
        }

        if (playerInput.Dash) {
            velocity += Vector3.Scale(transform.forward, DashDistance * new Vector3(
                Mathf.Log(1.0f / (Time.deltaTime * drag.x + 1)) / -Time.deltaTime,
                0.0f,
                Mathf.Log(1.0f / (Time.deltaTime * drag.z + 1)) / -Time.deltaTime));
        }

        velocity.y += gravity * Time.deltaTime;
 
        velocity.x /= 1 + (moveDrag + drag.x) * Time.deltaTime;
        velocity.y /= 1 + (moveDrag + drag.y) * Time.deltaTime;
        velocity.z /= 1 + (moveDrag + drag.z) * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime);
    }

    void OnControllerColliderHit(ControllerColliderHit other) {
        // Gets called whenever the character controller moves and intersects with another collider
    }
}
