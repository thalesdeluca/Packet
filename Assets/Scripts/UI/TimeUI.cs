using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TimeUI : MonoBehaviour {

    public GameController game;

    void LateUpdate() {
        GetComponent<Text>().text = (int)game.TimeCount + " ms";
    }
}