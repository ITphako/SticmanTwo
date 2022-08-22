using UnityEngine;

public class MoveTransition : Transition
{
    public override void Enable()
    {
    }

    private void Update()
    {
        NeedTransit = true;
    }
}
