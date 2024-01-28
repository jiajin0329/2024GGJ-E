
public class GameBGM : Singleton_MonoBehaviour<GameBGM>
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

    protected override void OnApplicationQuit()
    {
        base.OnApplicationQuit();
        enable = false;
    }
}
