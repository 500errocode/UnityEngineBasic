

public class Parallel : Composite
{

    public enum Policy
    {
        RequireOne,
        RequireAll,
    }
    private Policy _successpolicy;

    public Parallel(BehaviourTree tree) : base(tree)
    {
        _successpolicy = Policy.RequireOne;
    }

    public override Status Invoke()
    {
        int successCount = 0;
        foreach (Node child in children)
        {
            if (child.Invoke() == Status.Success)
                successCount++;
        }
        
        switch (_successpolicy)
        {
            case Policy.RequireOne:
                return successCount > 0 ?Status.Success : Status.Failure;
            case Policy.RequireAll:
                return successCount == children.Count ? Status.Success : Status.Failure;
            default:
                throw new System.Exception("[BehaviourTree.Parallel] : Wrong poluicy");
                }
    }
}