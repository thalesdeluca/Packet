using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CableScript : MonoBehaviour {
    private Vector3[] points;

    private bool onRange = false;
    private string plug;

    void Start() {
        GetComponent<LineRenderer>().GetPositions(points);
    }

    void FollowLine() {
        if (points.Length == 0) {
            return;
        }

        if (onRange) {
            if (plug == "Start") {

            } else {

            }
        }
    }

    public void ChangeOnRange(bool onRange, string name) {
        this.onRange = onRange;
        plug = name;
    }

}