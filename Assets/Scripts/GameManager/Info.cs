using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Info
{
    [Serializable]
    public enum Mode { test, game }
    [field:SerializeField] public Mode mode { get; private set; }

    public List<Controller> controllers;
}
