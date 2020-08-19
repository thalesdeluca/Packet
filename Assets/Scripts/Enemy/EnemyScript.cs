using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Behaviour {
    Idle,
    Towards
}

public enum EnemyState {
    Idle,
    Follow,
    Walk,
    Spot
}
public class EnemyScript : MonoBehaviour {

    public Behaviour startingBehaviour;
    private EnemyState state;

    private GameObject spottedObject;
    // Start is called before the first frame update
    void Start() {
        state = EnemyState.Idle;

        if (startingBehaviour == Behaviour.Towards) {
            state = EnemyState.Walk;
        }
    }

    // Update is called once per frame
    void Update() {
        UpdateState();
        HandleState();
    }

    void UpdateState() {
        if (spottedObject) {
            state = EnemyState.Spot;
        }
    }

    void HandleState() {
        switch (state) {
            case EnemyState.Follow:
                break;
            case EnemyState.Spot:
                //metal gear spotted
                break;
            case EnemyState.Walk:
                break;
            case EnemyState.Idle:
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.name == "Player") {
            spottedObject = other.gameObject;
        }
    }
}
