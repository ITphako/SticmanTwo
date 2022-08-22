using UnityEngine;

public class TransitionEnemy : MonoBehaviour
{
    [SerializeField] private StateEnemy _targetState;

    protected Player Target { get; private set; }

    public StateEnemy TargetState => _targetState;

    public bool NeedTransit { get; protected set; }

    public void Init(Player target)
    {
        Target = target;
    }

    private void OnEnable()
    {
        NeedTransit = false;
    }
}
