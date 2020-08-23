using System;
using System.Collections;
using UnityEngine;

public class GameController : MonoBehaviour {

    private float time = 0;

    public float timeLimit = 100f;

    private bool timeout = false;

    public float TimeCount {
        get { return time; }
    }
    void Start() {

    }

    void Update() {
        if (!timeout)
            time += Time.deltaTime;

        if (Input.GetButtonDown("Pause") && !timeout) {
            PauseManager.Instance.Pause();
        }

        if (time >= timeLimit && !timeout) {
            timeout = true;
            PauseManager.Instance.Pause(true);
            GetComponent<InputController>().BlockInput(true);
        }
    }
}