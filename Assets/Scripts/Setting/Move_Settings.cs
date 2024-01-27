using UnityEngine;

[CreateAssetMenu(fileName = nameof(Move_Settings), menuName = nameof(Move_Settings))]
public class Move_Settings : ScriptableObject
{
    public byte addForce = 50;
    public byte speed = 10;
    public byte jump = 5;
    public byte stopDrag = 50;
}
