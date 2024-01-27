using UnityEngine;

[CreateAssetMenu(fileName = nameof(Move_Setting), menuName = nameof(Move_Setting))]
public class Move_Setting : ScriptableObject
{
    public byte addForce = 50;
    public byte speed = 10;
    public byte jump = 5;
    public byte stopDrag = 50;
}
