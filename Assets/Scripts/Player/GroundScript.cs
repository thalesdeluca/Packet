using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : MonoBehaviour {

    private PlayerScript player;

    void Start() {
        player = GetComponentInParent<PlayerScript>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        player.isGrounded = true;
    }

    private void OnTriggerExit2D(Collider2D other) {
        player.isGrounded = false;
    }
}
