using System;

public class Excution : Node
{
    private Func<Status> _execute;

    public Excution(BehaviourTree tree, Func<Status> execute) : base(tree)
    {
        _execute = execute;
    }

    public override Status Invoke()
    {
        return _execute.Invoke();
    }
}

