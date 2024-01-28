using UnityEngine;

public class GameBGM : MonoBehaviour
{
    private bool enable;

    private void Start()
    {
        if (enable){
            Destroy(gameObject);
            return;
        }

        enable = true;
        DontDestroyOnLoad(gameObject);
    }

    private void OnApplicationQuit()
    {
        enable = false;
    }
}
