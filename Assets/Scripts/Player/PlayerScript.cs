using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    public InputController input;

    private PlayerState state;

    public bool isGrounded = true;

    private Rigidbody2D rigidbody;
    void Start() {
        state = new PlayerState();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update() {
        UpdateState();
        HandleState();
    }

    void HandleState() {
        switch (state.State) {
            case State.Idle:
                break;
            case State.Run:
                GetComponent<RunScript>().Run(input.map["horizontal"], rigidbody);
                break;
            case State.Jump:
                GetComponent<JumpScript>().Jump(rigidbody, input.map);
                break;
            case State.Rail:
                break;
        }
        Debug.Log(state.State);
    }

    void UpdateState() {
        if (input.map["jump"] != 0) {
            state.ChangeState(State.Jump);
        } else if (input.map["horizontal"] != 0 && state.State != State.Jump || state.State != State.Rail) {
            state.ChangeState(State.Run);
        } else if (input.map["rail"] != 0) {
            state.ChangeState(State.Rail);
        } else {
            state.ChangeState(State.Idle);
        }
    }



}