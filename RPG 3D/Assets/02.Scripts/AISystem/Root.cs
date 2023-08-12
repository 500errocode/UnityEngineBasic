public class Root : Node
{
    public Node child { get; set; }

    public override Status Invoke()
    {
        return child.Invoke();
    }
}