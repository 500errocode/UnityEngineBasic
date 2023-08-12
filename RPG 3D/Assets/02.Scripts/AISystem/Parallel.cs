

public class Parallel : Composite
{

    public enum Policy
    {
        ReauireOne,
        ReauireAll,
    }
    private Policy _successpolicy;

    public Parallel(Policy successpolicy)
    {
        _successpolicy = successpolicy;
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
            case Policy.ReauireOne:
                return successCount > 0 ?Status.Success : Status.Failure;
            case Policy.ReauireAll:
                return successCount == children.Count ? Status.Success : Status.Failure;
            default:
                throw new System.Exception("[BehaviourTree.Parallel] : Wrong poluicy");
                }
    }
}