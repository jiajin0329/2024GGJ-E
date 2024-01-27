using UnityEngine;

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
        foreach(var playerInfos in info.playerInfos)
        {
            playerInfos.controller.transform.position = playerInfos.startPosition;
            playerInfos.rigidbody2D.velocity = Vector3.zero;
            playerInfos.head.Reset();
        }
    }

    protected override void OnApplicationQuit()
    {
        base.OnApplicationQuit();
        switchControl.Disenable();

    }
}
