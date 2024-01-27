using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Controller controller;
    Animator ani;
    private void Start()
    {
        controller = GetComponent<Controller>();
        ani = GetComponentInChildren<Animator>();

        controller.MoveAction = Walk;
        controller.JumpAction = Jump;
        controller.RushDownAction = RushDown;
        controller.RushUPAction = RushUp;
        controller.IdleAction = Idle;
    }

    public void Idle()
    {
        ani.Play("Idle");
    }

    public void Walk()
    {
        ani.Play("Walk");
    }

    public void Jump()
    {
        ani.Play("Jump");
    }

    public void RushDown()
    {
        ani.Play("RushDown");
    }

    public void RushUp()
    {
        ani.Play("RushUp");
    }

}
