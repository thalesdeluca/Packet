using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScript : MonoBehaviour {
    public float jumpForce = 6f;

    private bool jumped = false;

    private PlayerScript player;

    void Start() {
        player = GetComponent<PlayerScript>();
    }
    public void Jump(Rigidbody2D rigidbody, Dictionary<string, float> input) {
        if (player.isGrounded) {
            rigidbody.AddForce(new Vector2(rigidbody.velocity.x, jumpForce), ForceMode2D.Impulse);
        }

        if (input["horizontal"] != 0) {
            GetComponent<RunScript>().Run(input["horizontal"], rigidbody);
        }
    }
}