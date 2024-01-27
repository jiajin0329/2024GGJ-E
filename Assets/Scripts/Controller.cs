using UnityEngine;
using UnityEngine.Events;

public class Controller : MonoBehaviour
{
    [field: SerializeField] public MoveState moveState { get; private set; }
    public enum Player_Type { Player1, Player2 }
    [field: SerializeField] public Player_Type player_Type { get; private set; }
    public UnityAction IdleAction;
    public UnityAction MoveAction;
    public UnityAction JumpAction;
    public UnityAction RushDownAction;
    public UnityAction RushUPAction;
    public enum MoveState { none, left, right, jump, stop }

    [SerializeField] private PC_Control_Settings pc_controlSettings_data;
    [SerializeField] private Ground_Trigger ground_Trigger;

    private PC_Control_Setting pc_control_setting;

    private void Start()
    {
        PlayerInfo playerInfo = new PlayerInfo()
        {
            controller = this,
            startPosition = transform.position,
            rigidbody2D = GetComponent<Rigidbody2D>(),
            head = GetComponent<Head>()
        };

        GameManager.instance.info.playerInfos.Add(playerInfo);
        pc_control_setting = pc_controlSettings_data.settings[(int)player_Type];
    }

    private void Update()
    {
        Move();
        Jump();
        Rush();
    }

    [ContextMenu(nameof(SwitchControl))]
    public void SwitchControl()
    {
        if (player_Type == Player_Type.Player1)
        {
            player_Type = Player_Type.Player2;
        }
        else
        {
            player_Type = Player_Type.Player1;
        }

        pc_control_setting = pc_controlSettings_data.settings[(int)player_Type];
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
                transform.localScale = new Vector3(-1, 1, 1);

                return;
            }
            else if (Input.GetKey(pc_control_setting.left))
            {
                moveState = MoveState.left;
                MoveAction?.Invoke();
                transform.localScale = Vector3.one;

                return;
            }

            if (moveState == MoveState.jump) return;
            moveState = MoveState.stop;
            MoveAction?.Invoke();
            IdleAction?.Invoke();
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

    private void Rush()
    {
        if (Input.GetKey(pc_control_setting.rush))
        {
            RushDownAction?.Invoke();
        }
        if (Input.GetKeyUp(pc_control_setting.rush))
        {
            RushUPAction?.Invoke();
        }
    }
}
