using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlinkingText : MonoBehaviour {

    public float blinkingTime = 1f;

    private float time = 0;

    public GameObject text;

    void Update() {
        time += Time.deltaTime;

        if (time >= blinkingTime) {
            time = 0;
            text.SetActive(!text.active);
        }

        if (Input.anyKeyDown) {
            SceneManager.LoadScene("GameLoop");
        }

    }
}