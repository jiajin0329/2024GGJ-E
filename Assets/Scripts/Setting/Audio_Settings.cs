using System;
using UnityEngine;

public enum AudioSelect
{
    move,
    jump,
    rush
};
[Serializable]
public struct Audio_Setting
{
    [field: SerializeField] public  AudioSelect audioSelect { get; private set; }
    [field:SerializeField] public  AudioClip audioClip { get; private set; }
}

[CreateAssetMenu(fileName = nameof(Audio_Settings), menuName = nameof(Audio_Settings))]
public class Audio_Settings : ScriptableObject
{
    [field: SerializeField] public Audio_Setting[] settings { get; private set; }
}
