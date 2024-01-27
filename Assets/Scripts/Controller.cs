using UnityEngine;
using UnityEngine.Events;

public class Controller : MonoBehaviour
{
    [field:SerializeField] public MoveState moveState { get; private set; }

    public UnityAction MoveAction;
    public UnityAction JumpAction;
    public enum MoveState {none, left, right, jump, stop}

    private enum Player_Type { Player1, Player2 }
    [SerializeField] private Player_Type player_Type;
    [SerializeField] private PC_Control_Settings pc_controlSettings_data;
    [SerializeField] private Ground_Trigger ground_Trigger;

    private PC_Control_Setting pc_control_setting;

    private void Start()
    {
        pc_control_setting = pc_controlSettings_data.control_settings[(int)player_Type];
    }

    private void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        if (ground_Trigger.trigger)
        {
            if (Input.GetKey(pc_control_setting.left) && Input.GetKey(pc_control_setting.right))
            {
                moveState = MoveState.stop;
                MoveAction?.Invoke();
                return;
            }
            else if (Input.GetKey(pc_control_setting.right))
            {
                moveState = MoveState.right;
                MoveAction?.Invoke();
                return;
            }
            else if (Input.GetKey(pc_control_setting.left))
            {
                moveState = MoveState.left;
                MoveAction?.Invoke();
                return;
            }

            if (moveState == MoveState.jump) return;
            moveState = MoveState.stop;
            MoveAction?.Invoke();
            return;
        }


        if (Input.GetKey(pc_control_setting.right))
        {
            moveState = MoveState.right;
            MoveAction?.Invoke();
            return;
        }
        else if (Input.GetKey(pc_control_setting.left))
        {
            moveState = MoveState.left;
            MoveAction?.Invoke();
            return;
        }


        moveState = MoveState.none;
        MoveAction?.Invoke();
        return;
    }

    private void Jump()
    {
        if (!ground_Trigger.trigger) return;
        if (!Input.GetKeyDown(pc_control_setting.up)) return;

        moveState = MoveState.jump;
        JumpAction?.Invoke();
    }
}
