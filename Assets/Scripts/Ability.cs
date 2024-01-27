using UnityEngine;
public class Ability : MonoBehaviour
{
    [SerializeField] private Controller _controller;

    [SerializeField] private float knockValue;

    [SerializeField] private float maxKnockValue;
    void Start()
    {
        Controller.RushAction = Knock;
    }
    public void RushDown()
    {
        // knockValue += Time.deltaTime;

    }
    public void RushUp()
    {

    }
}