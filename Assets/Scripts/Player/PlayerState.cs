using System;
using System.Collections;
using System.Collections.Generic;


public enum State {
    Idle,
    Run,
    Jump,
    Rail,
    Damage
}
public class PlayerState {
    private State state = State.Idle;

    public State State { get { return state; } }

    public PlayerState() {
        state = State.Idle;
    }

    public void ChangeState(State newState) {
        if (Enum.IsDefined(typeof(State), newState)) {
            state = newState;
        }
    }
}