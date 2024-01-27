using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton_MonoBehaviour<GameManager>
{
    [field:SerializeField] public Info info { get; private set; }
    [field:SerializeField] public SwitchControl switchControl { get; private set; }

    private void Start()
    {
        switchControl.Enable(info);
    }

    public void InitPlayer()
    {
        switchControl.Disenable();
        SceneManager.LoadScene(0);

        //foreach(var playerInfos in info.playerInfos)
        //{
        //    playerInfos.controller.transform.position = playerInfos.startPosition;
        //    playerInfos.rigidbody2D.velocity = Vector3.zero;
        //    playerInfos.head.Reset();
        //}
    }

    protected override void OnApplicationQuit()
    {
        base.OnApplicationQuit();
        switchControl.Disenable();
    }
}
