using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour {

    public HealthScript player;

    void LateUpdate() {
        GetComponent<Text>().text = player.health.ToString();
    }
}