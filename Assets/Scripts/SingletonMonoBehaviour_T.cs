using UnityEngine;

public class Singleton_MonoBehaviour<T> : MonoBehaviour where T : Singleton_MonoBehaviour<T> {
    public static T instance;

    protected virtual void Awake() {
        if (instance != null) {
            Destroy(gameObject);
            Debug.Log($"{typeof(T).Name} Destroy");
        }
        else {
            instance = (T)this;
            //Debug.Log($"{typeof(T).Name} Instance");
        }
    }

    protected virtual void OnApplicationQuit()
    {
        instance = null;
        //Debug.Log($"{typeof(T).Name} Null");
    }
}