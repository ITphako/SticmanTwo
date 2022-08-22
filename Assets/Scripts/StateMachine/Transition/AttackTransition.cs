using UnityEngine;

public class AttackTransition : Transition
{
    public override void Enable()
    {
    }

    private void Update()
    {
        NeedTransit = true;
    }
}
