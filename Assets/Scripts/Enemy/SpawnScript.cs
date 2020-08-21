using UnityEngine;
using System;
using System.Collections;


public enum SpawnType {
    Near,
    Offscreen
}
public class SpawnScript : MonoBehaviour {

    public GameObject target;

    public SpawnType type;

    public float offsetCamera = 1f;

    public Camera camera;

    private GameObject instantiated;
    private bool rendered = false;

    void Start() {

    }

    void Update() {

        if (!instantiated) {
            Vector2 position = camera.WorldToViewportPoint(this.transform.position);
            //is visible
            if (type != SpawnType.Offscreen) {
                Vector2 minBounds = new Vector2(-offsetCamera, -offsetCamera);
                Vector2 maxBounds = new Vector2(1 + offsetCamera, 1 + offsetCamera);
                bool isVisible = position.x > minBounds.x && position.y > minBounds.y && position.x < maxBounds.x && position.y < maxBounds.y;

                if (!rendered) {
                    if (isVisible) {
                        instantiated = Instantiate(target, this.transform);
                        rendered = true;
                    }
                } else {
                    if (!isVisible) {
                        instantiated = Instantiate(target, this.transform);
                    }
                }
            } else {
                instantiated = Instantiate(target, this.transform);
            }
        }

    }
}