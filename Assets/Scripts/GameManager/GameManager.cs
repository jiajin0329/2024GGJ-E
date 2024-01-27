
using UnityEngine;

public class GameManager : Singleton_MonoBehaviour<GameManager>
{
    [SerializeField] public Info info;

    public void InitPlayer()
    {
        foreach(var playerInfos in info.playerInfos)
        {
            playerInfos.controller.transform.position = playerInfos.startPosition;
            playerInfos.rigidbody2D.velocity = Vector3.zero;
            playerInfos.head.Reset();
        }
    }
}
