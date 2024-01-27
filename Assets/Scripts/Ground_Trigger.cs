using UnityEngine;

public class Ground_Trigger : MonoBehaviour
{
    public bool trigger { get { return triggerCount > 0; } private set { } }

    [SerializeField] private LayerMask targetMask;
    private byte targetLayer;
    private byte triggerCount;

    private void Start()
    {
        targetLayer = (byte)Mathf.Log(targetMask.value, 2f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer != targetLayer) return;
        triggerCount++;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer != targetLayer) return;
        triggerCount--;
    }
}
