using System;
using System.Collections;
using UnityEngine;

public class HealthScript : MonoBehaviour {

    public float health = 100f;

    public float hitCooldown = 2f;

    private float hitCount = 0;

    private bool hit = false;


    void Update() {
        if (hit) {
            hitCount += Time.deltaTime;
        }

        if (hitCount > hitCooldown) {
            hit = false;
            hitCount = 0;
        }
    }

    void TakeDamage(float damage) {
        if (health > 0 && !hit) {
            health -= damage;
            //play hit animation
            hit = true;

            if (health < 0) {
                health = 0;
                Destroy(this.gameObject);
                //play death animation
            }
        }
    }


}