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
        if (jumped && !player.isGrounded && rigidbody.velocity.y > 0) {
            GetComponent<Animator>().SetTrigger("OnAir");
        } else if (rigidbody.velocity.y <= 0 && !player.isGrounded && jumped) {
            GetComponent<Animator>().SetTrigger("Falling");
        } else if (jumped && player.isGrounded) {
            GetComponent<Animator>().SetTrigger("OnGround");
            jumped = false;
        }

        if (player.isGrounded) {
            rigidbody.AddForce(new Vector2(rigidbody.velocity.x, jumpForce), ForceMode2D.Impulse);
            jumped = true;
            GetComponent<Animator>().SetTrigger("Jumped");
        }



        if (input["horizontal"] != 0) {
            GetComponent<RunScript>().Run(input["horizontal"], rigidbody);
        }
    }
}