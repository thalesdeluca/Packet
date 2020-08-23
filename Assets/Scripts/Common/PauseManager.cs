using System;
using System.Collections;

using UnityEngine;

public class PauseManager : Singleton<PauseManager> {
    protected PauseManager() { }

    public bool Paused { get; private set; }

    public void Pause() {
        Paused = !Paused;
        if (Paused) {

            Time.timeScale = 0;
        } else {
            Time.timeScale = 1;
        }
        Debug.Log(Time.timeScale);
    }

    public void Pause(bool force) {
        Paused = force;
        if (Paused) {
            Time.timeScale = 0;
        } else {
            Time.timeScale = 1;
        }
        Debug.Log(Time.timeScale);
    }


}