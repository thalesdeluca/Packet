using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunScript : MonoBehaviour {
    public float moveSpeed = 100f;
    public void Run(float input, Rigidbody2D rigidbody) {
        Vector2 newVelocity = new Vector2(input * moveSpeed * Time.deltaTime, rigidbody.velocity.y);
        rigidbody.velocity = newVelocity;
    }
}