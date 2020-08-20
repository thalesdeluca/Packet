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

    // Start is called before the first frame update
    void Start() {
        state = EnemyState.Idle;

        if (startingBehaviour == Behaviour.Towards) {
            state = EnemyState.Walk;
        }
    }

    void Update() {
        GetComponent<SpotScript>().SearchingPlayer();
    }



}
