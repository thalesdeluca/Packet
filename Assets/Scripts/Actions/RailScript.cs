using System.Collections;
using System;
using UnityEngine;
using System.Collections.Generic;

public class RailScript : MonoBehaviour {

    private List<Vector2> gPoints;

    private PlayerScript player;

    private int actualPoint = 0;

    private float speed;

    private Rigidbody2D rigidbody;

    private bool waiting = false;

    public CameraScript camera;

    void Start() {
        player = GetComponent<PlayerScript>();
        gPoints = new List<Vector2>();
    }
    void Update() {
        if (player.isRailing) {
            if (actualPoint >= gPoints.Count) {
                ResetCable();
                return;
            }
            Vector2 bodyPosition = rigidbody.transform.position;


            rigidbody.transform.position = Vector2.MoveTowards(bodyPosition, gPoints[actualPoint], speed * Time.deltaTime);

            if (gPoints[actualPoint] == bodyPosition)
                actualPoint++;
        }
    }


    public void FollowLine(Rigidbody2D rigidbody, GameObject plug) {
        var cable = plug.transform.parent;

        var line = cable.GetComponent<LineRenderer>();
        speed = cable.GetComponent<CableScript>().speed;

        int count = line.positionCount;

        Vector3[] points = new Vector3[count];
        rigidbody.velocity = Vector2.zero;
        line.GetPositions(points);

        player.isRailing = true;
        actualPoint = 0;

        foreach (Vector3 vector in points) {
            gPoints.Add(vector);
        }

        if (plug.name == "End") {
            gPoints.Reverse();
        }

        this.rigidbody = rigidbody;

        camera.locked = true;
        rigidbody.bodyType = RigidbodyType2D.Kinematic;

    }

    private void ResetCable() {
        rigidbody.bodyType = RigidbodyType2D.Dynamic;
        camera.locked = false;
        actualPoint = 0;
        rigidbody.velocity = Vector2.zero;
        gPoints.Clear();
        player.isRailing = false;
    }
}