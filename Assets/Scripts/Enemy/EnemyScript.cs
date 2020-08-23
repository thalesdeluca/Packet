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

    public float damage = 20f;

    // Start is called before the first frame update
    void Start() {
        state = EnemyState.Idle;

        if (startingBehaviour == Behaviour.Towards) {
            state = EnemyState.Walk;
        }
    }

    void Update() {
        if (!PauseManager.Instance.Paused)
            GetComponent<SpotScript>().SearchingPlayer();
    }


    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.name == "Player") {
            other.collider.SendMessage("TakeDamage", damage);
            //Destroy animation
            Destroy(this.gameObject);
        }
    }

}
