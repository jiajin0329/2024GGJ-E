using UnityEngine;
using UnityEngine.Events;

public class Trigger_Event : MonoBehaviour
{
    protected UnityAction TriggerEnterAction;
    protected UnityAction TriggerExitAction;
    [SerializeField] protected LayerMask targetMask;
    private byte targetLayer;

    protected virtual void Start()
    {
        targetLayer = (byte)Mathf.Log(targetMask.value, 2f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer != targetLayer) return;
        TriggerEnterAction?.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer != targetLayer) return;
        TriggerExitAction?.Invoke();
    }
}
