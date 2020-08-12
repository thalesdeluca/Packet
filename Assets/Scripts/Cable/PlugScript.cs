using System.Collections;
using System;
using UnityEngine;

public class PlugScript : MonoBehaviour {

    public GameObject button;

    private Vector3 target;

    private GameObject m_button;

    void Start() {
        target = new Vector2(transform.position.x, transform.position.y + 2);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        m_button = Instantiate(button, target, Quaternion.identity);
        GetComponentInParent<CableScript>().ChangeOnRange(true, this.name);
    }

    private void OnTriggerExit2D(Collider2D other) {
        Destroy(m_button);
        m_button = null;
        GetComponentInParent<CableScript>().ChangeOnRange(false, this.name);

    }
}