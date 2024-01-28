using System;
using UnityEngine;

[Serializable]
public struct PC_Control_Setting
{
    public KeyCode up;
    public KeyCode down;
    public KeyCode left;
    public KeyCode right;
    public KeyCode rush;
}

[CreateAssetMenu(fileName = "PC_Control_Settings", menuName = "PC_Control_Settings")]
public class PC_Control_Settings : ScriptableObject
{
    public PC_Control_Setting[] settings;
}
