
using UnityEngine;

public class GameManager : Singleton_MonoBehaviour<GameManager>
{
    [SerializeField] public Info info;

    private void Start()
    {
        
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

    private void SwitchControl()
    {


        foreach (var playerInfos in info.playerInfos)
        {
            playerInfos.controller.SwitchControl();
        }
    }
}
