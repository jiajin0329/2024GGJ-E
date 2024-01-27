using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Controller controller;
    [SerializeField]private Animator aniHead;
    [SerializeField]private Animator aniBody;

    private bool jump;

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
        if (jump) return;

        aniHead.Play("Idle");
        aniBody.Play("Idle");
    }

    public void Walk()
    {
        if (jump) return;

        aniHead.Play("Walk");
        aniBody.Play("Walk");
    }

    public async void Jump()
    {
        jump = true;
        aniHead.Play("Jump");
        aniBody.Play("Jump");

        await UniTask.Delay(800);
        jump = false;
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
