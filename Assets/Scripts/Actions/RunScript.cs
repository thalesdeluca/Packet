using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunScript : MonoBehaviour {
    public float moveSpeed = 2f;

    public void Run(float input, Rigidbody2D rigidbody) {
        Vector2 newVelocity = new Vector2(input * moveSpeed * Time.fixedDeltaTime, rigidbody.velocity.y);
        rigidbody.velocity = newVelocity;

        if (input > 0) {
            GetComponent<SpriteRenderer>().flipX = false;
        } else {
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }
}