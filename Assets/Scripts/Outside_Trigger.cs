public class Outside_Trigger : Trigger_Event
{
    protected override void Start()
    {
        base.Start();
        TriggerEnterAction = OutSideAction;
    }

    private void OutSideAction()
    {
        
    }
}
