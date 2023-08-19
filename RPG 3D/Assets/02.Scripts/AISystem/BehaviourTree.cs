using System;
using UnityEngine;
using System.Collections.Generic;

public class BehaviourTree
{
    public Root root;
    public BlackBoard blackBoard;
    public bool isSleeping;

    public Status Tick()
    {
        return isSleeping ? Status.Running : root.Invoke();
    }

    private Node _current;
    private Stack<Composite> _compositeStack = new Stack<Composite>();

    public BehaviourTree StartBuild(GameObject owner)
    {
        blackBoard = new BlackBoard(owner);
        root = new Root(this);
        _current = root;
        return this;
    }

    public BehaviourTree ExitCurrentComposite()
    {
        if (_compositeStack.Count > 1)
        {
            _compositeStack.Pop();
            _current = _compositeStack.Peek();
        }
        else if (_compositeStack.Count == 1)
        {
            _compositeStack.Pop();
            _current = null;
        }
        return this;
    }

    public BehaviourTree Condition(Func<bool> condition)
    {
        Node node = new Condition(this, condition);
        AttachAsChild(_current, node);
        _current = node;
        return this;
    }

    public BehaviourTree Execution(Func<Status> execution)
    {
        Node node = new Excution(this, execution);
        AttachAsChild(_current, node);

        if (_compositeStack.Count > 0)
            _current = _compositeStack.Peek();
        else
            _current = null;

        return this;
    }

    public BehaviourTree Patrol(float radius)
    {
        Node node = new Patrol(this, radius);
        AttachAsChild(_current, node);

        if (_compositeStack.Count > 0)
            _current = _compositeStack.Peek();
        else
            _current = null;

        return this;
    }

    public BehaviourTree RandomSleep(float min, float max)
    {
        Node node = new RandomSleep(this, min, max);
        AttachAsChild(_current, node);

        if (_compositeStack.Count > 0)
            _current = _compositeStack.Peek();
        else
            _current = null;

        return this;
    }

    public BehaviourTree Selector()
    {
        Composite node = new Selector(this);
        AttachAsChild(_current, node);
        _current = node;
        _compositeStack.Push(node);
        return this;
    }

    public BehaviourTree Seek(float radius, float angle, float deltaAngle, LayerMask targetMask, Vector3 offset)
    {
        Node node = new Seek(this, radius, angle, deltaAngle, targetMask, offset);
        AttachAsChild(_current, node);

        if (_compositeStack.Count > 0)
            _current = _compositeStack.Peek();
        else
            _current = null;

        return this;
    }

    public BehaviourTree Sequence()
    {
        Composite node = new Sequence(this);
        AttachAsChild(_current, node);
        _current = node;
        _compositeStack.Push(node);
        return this;
    }

    public BehaviourTree Parallel(Parallel.Policy successPolicy)
    {
        Composite node = new Parallel(this);
        AttachAsChild(_current, node);
        _current = node;
        _compositeStack.Push(node);
        return this;
    }

    private void AttachAsChild(Node parent, Node child)
    {
        if (parent is IParentOfChild)
        {
            ((IParentOfChild)parent).child = child;
        }
        else if (parent is IParentOfChildren)
        {
            ((IParentOfChildren)parent).children.Add(child);
        }
        else
        {
            throw new Exception($"[BehaviourTree]: {parent.GetType()} 에다가는 자식 노드를 붙일 수 없습니다.");
        }
    }
}