using UnityEngine;

public class Move : MonoBehaviour {

    [SerializeField] private Move_Settings move_Setting;

    [SerializeField] private Controller controller;
    [SerializeField] private new Rigidbody2D rigidbody2D;

    private void Start ()
    {
        controller.MoveAction += MoveAction;
        controller.JumpAction += JumpAction;
    }

    private void LateUpdate()
    {
        SpeedLimit(move_Setting.speed);
    }

    private void MoveAction()
    {
        if (controller.moveState == Controller.MoveState.left)
        {
            rigidbody2D.drag = 0f;
            rigidbody2D.AddForce(new Vector2(-move_Setting.addForce, 0f));
        }
        else if (controller.moveState == Controller.MoveState.right)
        {
            rigidbody2D.drag = 0f;
            rigidbody2D.AddForce(new Vector2(move_Setting.addForce, 0f));
        }
        else if (controller.moveState == Controller.MoveState.stop)
        {
            rigidbody2D.drag = move_Setting.stopDrag;
        }
        else
        {
            rigidbody2D.drag = 0f;
        }

    }

    private void SpeedLimit(float speed)
    {
        if (rigidbody2D.velocity.x < 0 && rigidbody2D.velocity.x < -speed)
        {
            rigidbody2D.velocity = new Vector2(-speed, rigidbody2D.velocity.y);
        }
        else if (rigidbody2D.velocity.x > 0 && rigidbody2D.velocity.x > speed)
        {
            rigidbody2D.velocity = new Vector2(speed, rigidbody2D.velocity.y);
        }
    }

    private void JumpAction()
    {
        rigidbody2D.drag = 0f;
        rigidbody2D.velocity += new Vector2(rigidbody2D.velocity.x, move_Setting.jump);
    }
}
