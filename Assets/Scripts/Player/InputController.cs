using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputController : MonoBehaviour {

    public Dictionary<string, float> map = new Dictionary<string, float>();
    void Start() {
        map.Add("horizontal", 0f);
        map.Add("jump", 0f);
        map.Add("rail", 0f);
    }

    void Update() {
        map["horizontal"] = Input.GetAxis("Horizontal");
        map["jump"] = Convert.ToSingle(Input.GetButtonDown("Jump"));
        map["rail"] = Convert.ToSingle(Input.GetButtonDown("Rail"));


    }
}