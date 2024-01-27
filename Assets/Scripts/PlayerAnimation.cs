using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Controller controller;
    [SerializeField]private Animator aniHead;
    [SerializeField]private Animator aniBody;
    private void Start()
    {
        controller = GetComponent<Controller>();

        controller.MoveAction = Walk;
        controller.JumpAction = Jump;
        controller.RushDownAction = RushDown;
        controller.RushUPAction = RushUp;
        controller.IdleAction = Idle;
    }

    public void Idle()
    {
        aniHead.Play("Idle");
        aniBody.Play("Idle");
    }

    public void Walk()
    {
        aniHead.Play("Walk");
        aniBody.Play("Walk");
    }

    public void Jump()
    {
        aniHead.Play("Jump");
        aniBody.Play("Jump");
    }

    public void RushDown()
    {
        aniHead.Play("RushDown");
        aniBody.Play("RushDown");
    }

    public void RushUp()
    {
        aniHead.Play("RushUp");
        aniBody.Play("RushUp");
    }

}
