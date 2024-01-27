public class Ground_Trigger : Trigger_Event
{
    public bool trigger { get { return triggerCount > 0; } private set { } }
    private byte triggerCount;

    protected override void Start()
    {
        base.Start();
        TriggerEnterAction = () =>
        {
            triggerCount++;
        };

        TriggerExitAction = () =>
        {
            triggerCount--;
        };
    }
}
