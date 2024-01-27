using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo
{
    public Controller controller;
    public Vector3 startPosition;
}

[Serializable]
public class Info
{
    [Serializable]
    public enum Mode { test, game }
    [field:SerializeField] public Mode mode { get; private set; }

    public List<PlayerInfo> playerInfos;
}
