using System;
using System.Collections;
using UnityEngine;

public class GameController : MonoBehaviour {

    private float time = 0;

    public float TimeCount {
        get { return time; }
    }
    void Start() {

    }

    void Update() {
        time += Time.deltaTime;
    }
}