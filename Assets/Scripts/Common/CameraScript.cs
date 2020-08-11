﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    public Transform player;


    public float moveSpeed = 0.4f;

    public float offsetX = 0.20f;
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (player) {
            Vector3 target = new Vector3(player.position.x, transform.position.y, transform.position.z);
            Vector3 playerPosition = player.position;
            playerPosition.z = -10;
            transform.position = Vector3.Lerp(target, playerPosition, moveSpeed * Time.deltaTime);

        }
    }
}