using System;
using System.Collections;
using UnityEngine;

public class SpotScript : MonoBehaviour {

    public float maxRange = 5f;
    public float radius = 2f;
    public LayerMask collisionLayers;
    public LayerMask obstaclesLayers;

    private bool spotted = false;

    private Rigidbody2D rigidbody;

    public float moveSpeed = 50f;


    void Start() {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Spotted(GameObject player) {

        if (!spotted) {
            spotted = true;
            //Play animation
            //Wait animation
            //Change state to run'
        }

        FollowPlayer(player);
        Debug.Log(player);
    }

    void FollowPlayer(GameObject player) {
        Vector2 direction = (player.GetComponent<Rigidbody2D>().position - rigidbody.position).normalized;

        if (direction.x > 0) {
            GetComponent<SpriteRenderer>().flipX = true;
        } else {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        rigidbody.velocity = new Vector2(direction.x * moveSpeed * Time.deltaTime, rigidbody.velocity.y);
    }

    public void SearchingPlayer() {
        RaycastHit2D[] colliders = Physics2D.CircleCastAll(this.transform.position, radius, Vector2.left, maxRange, collisionLayers.value);

        foreach (var ray in colliders) {
            if (ray.collider.name == "Player") {
                Spotted(ray.collider.gameObject);
                break;
            }
        }
    }
}