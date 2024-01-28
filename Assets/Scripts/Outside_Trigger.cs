using System;
using UniRx;
using UnityEngine;

public class Outside_Trigger : Trigger_Event
{
    [SerializeField] private GameObject[] winPanel;
    int winner;
    protected override void Start()
    {
        base.Start();
        TriggerEnterAction = OutSideAction;
    }

    private void OutSideAction()
    {
        collision.gameObject.GetComponent<EffectController>().PlayDieParticle();

        if (collision.GetComponent<Controller>().player_Type == Controller.Player_Type.Player1)
        {
            Debug.Log("winner is player 2");
            winner = 1;
        }
        else
        {
            Debug.Log("winner is player 1");
            winner = 0;
        }
        Observable.EveryUpdate()
       .Delay(TimeSpan.FromSeconds(1.5f)).Subscribe(_ =>
       {

           winPanel[winner].SetActive(true);

       }).AddTo(this);
        Observable.EveryUpdate()
      .Delay(TimeSpan.FromSeconds(2.5f)).Subscribe(_ =>
      {

          winPanel[winner].SetActive(false);

          GameManager.instance.InitPlayer();

      }).AddTo(this);




    }
}
