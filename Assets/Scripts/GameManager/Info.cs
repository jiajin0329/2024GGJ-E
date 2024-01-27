using System;
using UnityEngine;

[Serializable]
public class Info
{
    [Serializable]
    public enum Mode { test, game }
    [field:SerializeField] public Mode mode { get; private set; }
}
