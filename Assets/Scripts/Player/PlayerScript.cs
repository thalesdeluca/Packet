using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    public InputController input;

    private PlayerState state;

    public bool isGrounded = true;
    public bool isRailing = false;

    private Rigidbody2D rigidbody;

    private GameObject cableInRange;

    private Animator animator;

    void Start() {
        state = new PlayerState();
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update() {
        UpdateState();
        HandleState();
    }

    void HandleState() {
        switch (state.State) {
            case State.Idle:
                //Resets horizontal velocity
                rigidbody.velocity = new Vector2(0, rigidbody.velocity.y);
                break;
            case State.Run:
                GetComponent<RunScript>().Run(input.map["horizontal"], rigidbody);
                break;
            case State.Jump:
                GetComponent<JumpScript>().Jump(rigidbody, input.map);
                break;
            case State.Rail:
                if (!isRailing) {
                    GetComponent<RailScript>().FollowLine(rigidbody, cableInRange);
                }
                break;

        }


    }

    void UpdateState() {
        if (input.map["rail"] != 0 && cableInRange || isRailing) {
            state.ChangeState(State.Rail);

        } else if (input.map["jump"] != 0 || !isGrounded) {
            state.ChangeState(State.Jump);
        } else if (input.map["horizontal"] != 0 && state.State != State.Jump) {
            state.ChangeState(State.Run);
        } else {
            state.ChangeState(State.Idle);
        }

        animator.SetBool("Grounded", isGrounded);
        animator.SetBool("Moving", input.map["horizontal"] != 0 || state.State == State.Run);
    }


    private void OnTriggerEnter2D(Collider2D other) {
        if (other.transform.parent.name == "Cable") {
            cableInRange = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.transform.parent.name == "Cable") {
            cableInRange = null;
        }
    }



}