using System;
using UnityEngine;

public enum AudioSelect
{
    UIOpen,
    UIClose,
    UIClick,
    MainMenu,
    SpaceBackground,
    End,
    Move,
    Jump,
    Rush,
    Hit,
    Rebound,
    DeathUpStart,
    DeathUpEnd,
    DeathDown,
};
[Serializable]
public struct Audio_Setting
{
    [field: SerializeField] public  AudioSelect audioSelect { get; private set; }
    [field:SerializeField] public  AudioClip audioClip { get; private set; }
}

[CreateAssetMenu(fileName = "Audio_Settings", menuName = "Audio_Settings")]
public class Audio_Settings : ScriptableObject
{
    [field: SerializeField] public Audio_Setting[] settings { get; private set; }

}
