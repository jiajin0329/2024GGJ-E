using UnityEngine;

[CreateAssetMenu(fileName = "Move_Settings", menuName = "Move_Settings")]
public class Move_Settings : ScriptableObject
{
    public byte addForce = 50;
    public byte speed = 10;
    public byte jump = 5;
    public byte stopDrag = 50;
}
