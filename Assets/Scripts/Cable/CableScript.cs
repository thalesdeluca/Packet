using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CableScript : MonoBehaviour {
    private Vector3[] points;

    public float speed = 2f;
    private bool onRange = false;
    private string plug;

    void Start() {
        points = new Vector3[1000000];
        GetComponent<LineRenderer>().GetPositions(points);
    }



    public void ChangeOnRange(bool onRange, string name) {
        this.onRange = onRange;
        plug = name;
    }

}