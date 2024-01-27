using System;
using UniRx;
using UnityEngine;
public class Ability : MonoBehaviour
{
    public enum RushState
    {
        none, isRushing, getKnock
    }
    private Controller controller;
    private Rigidbody2D rb2D;

    [SerializeField] private float rushValue;

    [SerializeField] private float maxRushValue;
    [SerializeField] private float rushTime;
    [SerializeField] private float rushCoolTime;
    private bool canRush = true;

    private Head head;
    public RushState rushState = RushState.none;
    private IDisposable stopRushRoutine;
    private IDisposable rushCoolTimeRoutine;

    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        controller = gameObject.GetComponent<Controller>();
        head = gameObject.GetComponent<Head>();

        controller.RushDownAction = RushDown;
        controller.RushUPAction = RushUp;
    }
    public void RushDown()
    {

        if (!canRush) return;

        rushValue += 10 * Time.deltaTime;
        if (rushValue >= maxRushValue)
            rushValue = maxRushValue;
    }
    public void RushUp()
    {
        canRush = false;
        controller.enabled = false;

        rushState = RushState.isRushing;

        rb2D.drag = 0f;
        rb2D.AddForce(transform.right * transform.localScale.x * rushValue * 100);
        rushValue = 0;

        rushCoolTimeRoutine = Observable.EveryUpdate().First()
        .Delay(TimeSpan.FromSeconds(rushCoolTime)).Subscribe(_ =>
        {
            canRush = true;
            rushCoolTimeRoutine?.Dispose();
        }).AddTo(this);

        stopRushRoutine = Observable.EveryUpdate().First().Delay(TimeSpan.FromSeconds(rushTime))
        .Subscribe(_ =>
        {
            StopRush();

        }).AddTo(this);
    }
    void StopRush()
    {
        controller.enabled = true;
        rb2D.velocity = Vector2.zero;
        rushState = RushState.none;

        stopRushRoutine?.Dispose();
    }

    public void GetKnock(Transform dir, int headLevelAddition)
    {
        if (rushState != RushState.isRushing)
        {
            head.IncreaseHeadLevel();

        }
        Debug.Log(this.name + "get knock");
        rushState = RushState.getKnock;

        rb2D.velocity = Vector2.zero;

        rb2D.drag = 0;
        Vector2 knockDir = (transform.position - dir.position).normalized;
        rb2D.AddForce(knockDir * headLevelAddition * 10000);
        Observable.EveryUpdate().First().Delay(TimeSpan.FromSeconds(1f)).Subscribe(_ =>
        {
            rushState = RushState.none;

        }).AddTo(this);


    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (rushState == RushState.none) return;
        if (rushState == RushState.getKnock) return;
        if (other.gameObject.TryGetComponent<Ability>(out var target))
        {
            StopRush();
            var headLevel = head.headLevel;
            target.GetKnock(this.transform, headLevel);
        }

    }

}