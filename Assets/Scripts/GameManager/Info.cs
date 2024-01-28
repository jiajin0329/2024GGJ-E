using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerInfo
{
    public Controller controller;
    public Vector3 startPosition;
    public Rigidbody2D rigidbody2D;
    public Head head;
    public Character_Sprites character_sprites;
}

[Serializable]
public class Info
{
    [Serializable]
    public enum Mode { test, game }
    [field:SerializeField] public Mode mode { get; private set; }

    public List<PlayerInfo> playerInfos;

    public void AddCharacter_Sprites(Character_Sprites character_sprites, Controller controller)
    {
        foreach (PlayerInfo playerInfo in playerInfos)
        {
            if(playerInfo.controller == controller) {
                playerInfo.character_sprites = character_sprites;
            }
        }
    }
}
