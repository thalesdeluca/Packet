using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour {
    private static T instance;

    public static T Instance {
        get {
            if (instance == null) {
                instance = GameObject.FindObjectOfType<T>();

                if (instance == null) {
                    GameObject gameObject = new GameObject("PauseManager");
                    instance = gameObject.AddComponent<T>();
                }
            }
            return instance;
        }
    }
}