using System.Collections;
using System;
using UnityEngine;

public class PlugScript : MonoBehaviour {

    public GameObject button;

    private Vector3 target;

    private GameObject m_button;

    void Start() {
        target = new Vector2(transform.position.x, transform.position.y + 0.3f);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.name == "Player") {
            m_button = Instantiate(button, target, Quaternion.identity);
            GetComponentInParent<CableScript>().ChangeOnRange(true, this.name);
        }

    }

    private void OnTriggerExit2D(Collider2D other) {
        if (m_button) {
            Destroy(m_button);
            m_button = null;
            GetComponentInParent<CableScript>().ChangeOnRange(false, this.name);
        }


    }
}