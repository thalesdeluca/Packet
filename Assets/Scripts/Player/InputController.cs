using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputController : MonoBehaviour {

    public Dictionary<string, float> map = new Dictionary<string, float>();

    public bool blocked = false;
    void Start() {
        map.Add("horizontal", 0f);
        map.Add("jump", 0f);
        map.Add("rail", 0f);
    }

    void Update() {
        if (!blocked) {
            map["horizontal"] = Input.GetAxis("Horizontal");
            map["jump"] = Convert.ToSingle(Input.GetButtonDown("Jump"));
            map["rail"] = Convert.ToSingle(Input.GetButtonDown("Rail"));

        }


    }

    public void BlockInput(bool blocked) {
        if (blocked) {
            this.blocked = blocked;
            foreach (var input in map) {
                map[input.Key] = 0;
            }
        }
    }
}