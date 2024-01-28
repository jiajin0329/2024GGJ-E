using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton_MonoBehaviour<GameManager>
{
    [field:SerializeField] public Info info { get; private set; }
    [field:SerializeField] public SwitchPlayer switchPlayer { get; private set; }

    private void Start()
    {
        switchPlayer.Enable(info);
    }

    public void InitPlayer()
    {
        switchPlayer.Disenable();
        SceneManager.LoadScene(1);
    }

    protected override void OnApplicationQuit()
    {
        base.OnApplicationQuit();
        switchPlayer.Disenable();
    }
}
